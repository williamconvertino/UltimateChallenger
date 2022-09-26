using System;
using Stage;
using UnityEngine;

public abstract class Challenge : MonoBehaviour
{
    public bool IsChallengeOver { protected set; get; }
    protected GameObject[] Players;
    protected abstract void Cleanup();
    public void Init(GameObject[] players)
    {
        Players = players;
    }
}
