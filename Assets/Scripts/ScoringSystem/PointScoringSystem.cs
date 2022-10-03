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
        foreach (GameObject player in winners)
        {
            _playerScore[player]++;
            if (_playerScore[player] > _highestScore)
            {
                _highestScore++;
            }
        }
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

    public override void PrintScores()
    {
        foreach (GameObject player in _playerScore.Keys)
        {
            //Debug.Log(player.GetComponent<PlayerInfo>().GetPlayerName() + ": " + _playerScore[player] + " points.");
        }
    }
}
