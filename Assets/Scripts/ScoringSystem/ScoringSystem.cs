using UnityEngine;
using UnityEngine.PlayerLoop;

public abstract class ScoringSystem : MonoBehaviour
{
    protected GameObject[] Players;
    
    public virtual void Init(GameObject[] players)
    {
        Players = players;
    }

    public abstract void UpdateLosers(GameObject[] losers);
    public abstract void UpdateWinners(GameObject[] winners);

    public abstract bool IsGameOver();
    public abstract GameObject[] GetWinners();
}
