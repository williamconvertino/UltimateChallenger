using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class LifeScoringSystem : ScoringSystem
{
    [SerializeField] private int numLives;

    private Dictionary<GameObject, int> playerLives;
    private List<GameObject> remainingPlayers;
    private int _highestLifeTotal;

    public override void Init(GameObject[] players)
    {
        base.Init(players);
        playerLives = new Dictionary<GameObject, int>();
        _highestLifeTotal = numLives;
        remainingPlayers = new List<GameObject>();
        foreach (GameObject player in players)
        {
            playerLives.Add(player, numLives);
            remainingPlayers.Add(player);
        }
    }
    public override void UpdateLosers(GameObject[] losers)
    {
        foreach (GameObject player in losers)
        {
            playerLives[player] -= 1;
            if (playerLives[player] < 1)
            {
                remainingPlayers.Remove(player);
                player.SetActive(false);
            }

            _highestLifeTotal = Math.Max(_highestLifeTotal, playerLives[player]);
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
        foreach (GameObject player in playerLives.Keys)
        {
            if (playerLives[player] == _highestLifeTotal)
            {
                highestLifePlayers.Add(player);
            }
        }

        return highestLifePlayers.ToArray();
    }
}
