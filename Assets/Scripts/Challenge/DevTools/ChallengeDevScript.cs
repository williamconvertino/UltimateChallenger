using System;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeDevScript : MonoBehaviour
{
    public GameObject[] playerPrefabs;
    protected List<GameObject> ActivePlayers;

    protected virtual void Start()
    {
        SpawnPlayers();
        
        gameObject.GetComponent<Challenge>().Init(ActivePlayers.ToArray());
    }

    protected virtual void SpawnPlayers()
    {
        foreach (GameObject player in playerPrefabs)
        {
            ActivePlayers.Add(Instantiate(player, Vector3.zero, Quaternion.identity ));
        }
    }
}