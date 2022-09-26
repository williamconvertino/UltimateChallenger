using System;
using UnityEngine;

public class TimedChallengeDevScript : ChallengeDevScript
{
    public float timer;

    protected override void Start()
    {
        SpawnPlayers();
        gameObject.GetComponent<TimedChallenge>().Init(ActivePlayers.ToArray(), timer);
    }
}