using System;
using UnityEngine;

public class ChallengeDevScript : UnityEngine.MonoBehaviour
{
    public GameObject[] players;
    public GameObject stage;

    protected virtual void Start()
    {
        GetComponentInChildren<Challenge>().Init(players);
        GetComponent<RespawnManager>().Init(players, stage);
    }
}
