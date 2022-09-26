using System;
using Stage;
using Unity.VisualScripting;
using UnityEngine;

public abstract class TimedChallenge : Challenge
{
    private float timer;
    
    public void Init(GameObject[] players, float challengeTime = Mathf.Infinity)
    {
        base.Init(players);
        timer = challengeTime;
    }

    private void Update()
    {
        UpdateTimer();
    }
    
    private void UpdateTimer()
    {   
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            IsChallengeOver = true;
        }
    }
}
