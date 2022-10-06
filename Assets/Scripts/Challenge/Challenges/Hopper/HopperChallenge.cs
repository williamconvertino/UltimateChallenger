using System;
using System.Collections.Generic;
using UnityEngine;

public class HopperChallenge : Challenge
{
    private List<HopperPlayerScript> _playerScripts;

    public override void Init(GameObject[] players, Stage stage)
    {
        base.Init(players, stage);
        _playerScripts = AddScriptToPlayers<HopperPlayerScript>();
    }

    private void Update()
    {
        CheckVictory();
    }

    public override void OnPlayerRespawn(GameObject player)
    {
        base.OnPlayerRespawn(player);
        player.GetComponent<HopperPlayerScript>().Hit();
    }

    protected override void CheckVictory()
    {
        int numActive = 0;
        foreach (HopperPlayerScript playerScript in _playerScripts)
        {
            if (!playerScript.playerIsOut)
            {
                numActive++;
            }
        }

        if (numActive <= 1)
        {
            IsChallengeOver = true;
        }
    }
    
    public override GameObject[] GetWinners()
    {
        List<GameObject> winners = new List<GameObject>();
        foreach (HopperPlayerScript playerScript in _playerScripts)
        {
            if (!playerScript.playerIsOut)
            {
                winners.Add(playerScript.Player);
            }
        }

        return winners.ToArray();
    }
    public override GameObject[] GetLosers()
    {
        List<GameObject> losers = new List<GameObject>();
        foreach (HopperPlayerScript playerScript in _playerScripts)
        {
            if (playerScript.playerIsOut)
            {
                losers.Add(playerScript.Player);
            }
        }

        return losers.ToArray();
    }
}