using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class RespawnManager : MonoBehaviour
{
    
    public static List<GameObject> GlobalPlayerList;
    
    [SerializeField] private GameObject[] playerPrefabs;
    private List<GameObject> _activePlayers;
    private List<GameObject> _respawnerList;
    // Start is called before the first frame update
    private void Start()
    {
        InitializeGlobalPlayerList();
        _activePlayers = new List<GameObject>();
        _respawnerList = new List<GameObject>();
        foreach (Transform rsTransform in gameObject.transform)
        {
            _respawnerList.Add(rsTransform.gameObject);
        }
        
        foreach (GameObject playerPrefab in playerPrefabs)
        {
            GlobalPlayerList.Add(playerPrefab);
        }
        
        foreach (GameObject playerPrefab in GlobalPlayerList)
        {
            RespawnPlayer(Instantiate(playerPrefab));
        }
    }

    private void InitializeGlobalPlayerList()
    {
        if (GlobalPlayerList == null)
        {
            GlobalPlayerList = new List<GameObject>();
        }
    }

    private void RespawnPlayer(GameObject player)
    {
        _activePlayers.Remove(player);
        player.transform.position = GetBestRespawner().GetComponent<Respawner>().GetUsableLocation();
        _activePlayers.Add(player);
    }

    private GameObject GetBestRespawner()
    {
        
        GameObject bestRespawner = _respawnerList[new Random().Next(_respawnerList.Count)];
        float bestNearestPlayerDistance = 0;
        
        foreach (GameObject rs in _respawnerList)
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
    
    private void Update()
    {
        List<GameObject> deadPlayers = new List<GameObject>();
        foreach (GameObject player in _activePlayers)
        {
            if (!IsPlayerAlive(player))
            {
                deadPlayers.Add(player);
            }
        }

        foreach (GameObject player in deadPlayers)
        {
            RespawnPlayer(player);
        }
    }

    private bool IsPlayerAlive(GameObject player)
    {
        return player.transform.position.y > -8;
    }
}
