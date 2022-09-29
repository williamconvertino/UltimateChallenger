
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class RespawnManager : MonoBehaviour
{
    #region Core

    private GameObject[] _allPlayers;
    private List<GameObject> _activePlayers;
    
    public void Init(GameObject[] players, GameObject stage)
    {
        _allPlayers = players;
        _activePlayers = new List<GameObject>(players);
        SetRespawners(stage);
        SpawnAllPlayers();
    }

    private void Update()
    {
        CheckPlayerRespawn();
    }

    #endregion

    #region Challenge Script

    private Challenge _currentChallenge;
    public void SetChallenge(Challenge challengeScript)
    {
        _currentChallenge = challengeScript;
    }

    #endregion
    
    #region Spawning
    
    private void SpawnAllPlayers()
    {
        foreach (GameObject player in _allPlayers)
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
        player.SetActive(true);
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

    private void Respawn(GameObject player)
    {
        if (_currentChallenge != null)
        {
            _currentChallenge.OnPlayerRespawn(player);
        }
        SpawnPlayer(player);
    }
    private void CheckPlayerRespawn()
    {
        foreach (GameObject player in _allPlayers)
        {
            if (PlayerNeedsRespawn(player))
            {
                Respawn(player);
            }
        }
    }

    private bool PlayerNeedsRespawn(GameObject player)
    {
        return player.transform.position.y <= -5;
    }

    #endregion
}
