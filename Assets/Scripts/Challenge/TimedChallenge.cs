using System;
using Stage;
using Unity.VisualScripting;
using UnityEngine;

public abstract class TimedChallenge : Challenge
{
    
    private float challengeTime;
    private float timeRemaining;
    
    public void Init(GameObject[] players, float time = 0)
    {
        base.Init(players);
        challengeTime = time;
    }

    private void Update()
    {
        UpdateTimer();
    }
    
    private void UpdateTimer()
    {   
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0)
        {
            IsChallengeOver = true;
        }
    }
}
