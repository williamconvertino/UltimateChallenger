using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PointScoringSystem : ScoringSystem
{
    [SerializeField] private int pointsToWin = 9999;
    private int _highestScore = 0;
    private Dictionary<GameObject, int> _playerScore;

    public override void Init(GameObject[] players)
    {
        base.Init(players);
        _playerScore = new Dictionary<GameObject, int>();
        foreach (GameObject player in players)
        {
            _playerScore.Add(player, 0);
        }
    }
    public override void UpdateLosers(GameObject[] losers)
    {
        
    }

    public override void UpdateWinners(GameObject[] winners)
    {
        StringBuilder message = new StringBuilder("------------\n Game winners:\n");

        foreach (GameObject player in winners)
        {
            message.Append(player.GetComponent<PlayerInfo>().GetPlayerName());
            message.Append(",\n");
            _playerScore[player]++;
            if (_playerScore[player] > _highestScore)
            {
                _highestScore++;
            }
        }
        message.Append("\n------------");
        Debug.Log(message);
    }

    public override bool IsGameOver()
    {
        return _highestScore == pointsToWin;
    }

    public override GameObject[] GetWinners()
    {
        List<GameObject> winningPlayers = new List<GameObject>();
        foreach (GameObject player in Players)
        {
            if (_playerScore[player] == _highestScore)
            {
                winningPlayers.Add(player);
            }
        }

        return winningPlayers.ToArray();
    }
}
