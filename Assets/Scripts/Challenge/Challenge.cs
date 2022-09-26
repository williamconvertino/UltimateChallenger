using UnityEngine;

public abstract class Challenge : MonoBehaviour
{
    public bool IsChallengeOver { protected set; get; } = false;
    protected GameObject[] Players;
    protected abstract void Cleanup();
    public virtual void Init(GameObject[] players)
    {
        Players = players;
    }
}
