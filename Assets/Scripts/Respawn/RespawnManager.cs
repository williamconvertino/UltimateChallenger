
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    #region Core

    private GameObject[] _playerPrefabs;
    private List<GameObject> _activePlayers;

    public void Init(GameObject[] players, GameObject stage)
    {
        _playerPrefabs = players;
        _activePlayers = new List<GameObject>();
        SetRespawners(stage);
        InitializePlayers();
        SpawnAllPlayers();
    }

    private void Update()
    {
        CheckPlayerRespawn();
    }

    #endregion

    #region Spawning

    private void InitializePlayers()
    {
        foreach (GameObject player in _playerPrefabs)
        {
            _activePlayers.Add(Instantiate(player, transform)); 
        }
    }
    private void SpawnAllPlayers()
    {
        foreach (GameObject player in _activePlayers.ToList())
        {
            SpawnPlayer(player);
        }
    }

    private void SpawnPlayer(GameObject player)
    {
        _activePlayers.Remove(player);
        Vector2 position = GetBestRespawner().GetUsableLocation();
        player.transform.position = position;
        _activePlayers.Add(player);
    }

    //Deletes all the instantiated players, removing them from the game.
    private void ClearAllPlayers()
    {
        foreach (GameObject player in _activePlayers)
        {
            if (player != null)
            {
                Destroy(player);
            }
        }
        _activePlayers.Clear();
    }

    #endregion
    
    #region Respawners
    private Respawner[] _respawners;

    private void SetRespawners(GameObject stage)
    {
        _respawners = stage.GetComponentsInChildren<Respawner>();
    }
    
    //Finds the respawner whose nearest player is the greatest distance away.
    private Respawner GetBestRespawner()
    {
        Respawner bestRespawner = _respawners[Random.Range(0,_respawners.Length)];
        float bestNearestPlayerDistance = 0;
        
        foreach (Respawner rs in _respawners)
        {
            float nearestPlayerDistance = Mathf.Infinity;
            Vector2 rsPos = rs.transform.position;
            foreach (GameObject player in _activePlayers)
            {
                float distance = Vector2.Distance(rsPos, player.transform.position);
                if (distance < nearestPlayerDistance)
                {
                    nearestPlayerDistance = distance;
                }
            }

            if (nearestPlayerDistance > bestNearestPlayerDistance)
            {
                bestNearestPlayerDistance = nearestPlayerDistance;
                bestRespawner = rs;
            }
        }
        return bestRespawner;
    }
    #endregion

    #region RespawnChecking

    private void CheckPlayerRespawn()
    {
        foreach (GameObject player in _activePlayers.ToList())
        {
            if (PlayerNeedsRespawn(player))
            {
                SpawnPlayer(player);
            }
        }
    }

    private bool PlayerNeedsRespawn(GameObject player)
    {
        return player.transform.position.y <= -5;
    }

    #endregion
}
