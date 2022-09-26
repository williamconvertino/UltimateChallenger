using System;
using Stage;
using Unity.VisualScripting;
using UnityEngine;

public abstract class TimedChallenge : Challenge
{
    [SerializeField] private float challengeTime = Mathf.Infinity;

    private float timer;

    private void Start()
    {
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
            print(""Challenge over);
            Cleanup();
            IsChallengeOver = true;
        }
    }
}
