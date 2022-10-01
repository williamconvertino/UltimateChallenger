using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class LifeScoringSystem : ScoringSystem
{
    [SerializeField] private int numLives;

    private Dictionary<GameObject, int> _playerLives;
    private List<GameObject> remainingPlayers;
    private int _highestLifeTotal;

    public override void Init(GameObject[] players)
    {
        base.Init(players);
        _playerLives = new Dictionary<GameObject, int>();
        _highestLifeTotal = numLives;
        remainingPlayers = new List<GameObject>();
        foreach (GameObject player in players)
        {
            _playerLives.Add(player, numLives);
            remainingPlayers.Add(player);
        }
    }
    public override void UpdateLosers(GameObject[] losers)
    {
        foreach (GameObject player in losers)
        {
            _playerLives[player] -= 1;
            if (_playerLives[player] < 1)
            {
                remainingPlayers.Remove(player);
                player.SetActive(false);
            }

            _highestLifeTotal = Math.Max(_highestLifeTotal, _playerLives[player]);
        }
    }

    public override void UpdateWinners(GameObject[] winners)
    {
        
    }

    public override bool IsGameOver()
    {
        return remainingPlayers.Count == 1;
    }

    public override GameObject[] GetWinners()
    {
        List<GameObject> highestLifePlayers = new List<GameObject>();
        foreach (GameObject player in _playerLives.Keys)
        {
            if (_playerLives[player] == _highestLifeTotal)
            {
                highestLifePlayers.Add(player);
            }
        }

        return highestLifePlayers.ToArray();
    }

    public override void PrintScores()
    {
        foreach (GameObject player in _playerLives.Keys)
        {
            Debug.Log(player.GetComponent<PlayerInfo>().GetPlayerName() + ": " + _playerLives[player] + " lives.");
        }
    }
}
