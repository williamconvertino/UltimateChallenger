using System;
using Stage;
using Unity.VisualScripting;
using UnityEngine;

public abstract class TimedChallenge : Challenge
{
    [SerializeField] private float challengeTime = Mathf.Infinity;

    private float timer;

    protected virtual void Start()
    {
        timer = challengeTime;
    }
    
    protected virtual void Update()
    {
        UpdateTimer();
    }
    
    private void UpdateTimer()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Cleanup();
            IsChallengeOver = true;
        }
    }
}
