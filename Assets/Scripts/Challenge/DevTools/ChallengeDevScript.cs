using System;
using UnityEngine;

public class ChallengeDevScript : UnityEngine.MonoBehaviour
{
    public GameObject[] players;

    protected virtual void Start()
    {
        gameObject.GetComponent<Challenge>().Init(players);
    }
}
