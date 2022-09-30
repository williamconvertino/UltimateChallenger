using System.Collections.Generic;
using UnityEngine;

public class SnakeChallenge : TDChallenge
{
    private List<SnakePlayerScript> _playerScripts;
    public override void Init(GameObject[] players)
    {
        base.Init(players);
        _playerScripts = AddScriptToPlayers<SnakePlayerScript>();
        Debug.Log("Starting Snake");
    }

    protected override void CheckVictory()
    {
        IsChallengeOver = false;
    }
}
