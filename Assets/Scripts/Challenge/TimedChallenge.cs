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
        CheckVictory();
    }
    #endregion

    #region Timer

    [SerializeField] private float challengeTime = Mathf.Infinity;
    private float timer;
    private void UpdateTimer()
    {
        timer -= Time.deltaTime;
    }

    protected override void CheckVictory()
    {
        if (timer <= 0)
        {
            IsChallengeOver = true;
        }
    }

    #endregion
}
