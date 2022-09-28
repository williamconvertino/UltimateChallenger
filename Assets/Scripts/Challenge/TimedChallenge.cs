using System;
using Stage;
using Unity.VisualScripting;
using UnityEngine;

public abstract class TimedChallenge : Challenge
{
    #region Initialization

    public override void Init(GameObject[] players)
    {
        base.Init(players);
        timer = challengeTime;
    }
    
    #endregion

    #region Update
    protected virtual void Update()
    {
        UpdateTimer();
    }
    #endregion

    #region Timer
    [SerializeField] private float challengeTime = Mathf.Infinity;
    private float timer;
    private void UpdateTimer()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Cleanup();
            IsChallengeOver = true;
        }
    }
    #endregion
}
