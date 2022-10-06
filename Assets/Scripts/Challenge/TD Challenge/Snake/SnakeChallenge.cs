using System.Collections.Generic;
using UnityEngine;

public class SnakeChallenge : TDChallenge
{
    private List<SnakePlayerScript> _playerScripts;
    private Stage snakeStage;
    public override void Init(GameObject[] players, Stage stage)
    {
        base.Init(players, stage);
        _playerScripts = AddScriptToPlayers<SnakePlayerScript>();
        _setStage(Resources.Load<GameObject>("Prefabs/Stages/TDGameBorders").GetComponent<Stage>());
        Debug.Log("Starting Snake");
    }
    
    public override void OnPlayerRespawn(GameObject player)
    {
        player.GetComponent<SnakePlayerScript>().Hit();
    }

    private void Update()
    {
        CheckVictory();
    }
    
    protected override void CheckVictory()
    {
        int livePlayers = 0;
        foreach (SnakePlayerScript playerScript in _playerScripts)
        {
            if (!playerScript.IsOut)
            {
                livePlayers++;
            }
        }

        if (livePlayers < 2)
        {
            IsChallengeOver = true;
        }
    }
    
    
    public override GameObject[] GetWinners()
    {
        List<GameObject> winners = new List<GameObject>();
        foreach (SnakePlayerScript playerScript in _playerScripts)
        {
            if (!playerScript.IsOut)
            {
                winners.Add(playerScript.Player);
            }
        }

        return winners.ToArray();
    }
    public override GameObject[] GetLosers()
    {
        List<GameObject> losers = new List<GameObject>();
        foreach (SnakePlayerScript playerScript in _playerScripts)
        {
            if (playerScript.IsOut)
            {
                losers.Add(playerScript.Player);
            }
        }

        return losers.ToArray();
    }

    public override void Cleanup()
    {
        base.Cleanup();
        _resetStage();
    }
}
