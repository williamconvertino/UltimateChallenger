using System;
using UnityEngine;

public class TimedChallengeDevScript : ChallengeDevScript
{
    public float timer;

    protected override void Start()
    {
        TimedChallenge challengeScript = gameObject.GetComponent<TimedChallenge>();
        challengeScript.Init(players, timer);
    }
}