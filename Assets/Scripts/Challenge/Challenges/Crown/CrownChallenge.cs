using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class CrownChallenge : TimedChallenge
{
    #region Initialization
    
    private List<CrownPlayerScript> _playerScripts;
    public override void Init(GameObject[] players)
    {
        base.Init(players);
        AddScriptToPlayers<CrownPlayerScript>();
        _playerScripts = GetPlayerScripts<CrownPlayerScript>();
        CrownPlayerScript initialCrown = _playerScripts[Random.Range(0,_playerScripts.Count)];
        initialCrown.Crown();
        Debug.Log("Starting Crown");
    }
    #endregion

    #region On Respawn

    public override void OnPlayerRespawn(GameObject player)
    {
        CrownPlayerScript playerScript = player.GetComponent<CrownPlayerScript>();
        if (!playerScript.Crowned || _playerScripts.Count < 2)
        {
            return;
        }

        CrownPlayerScript newCrowned = playerScript;
        while (newCrowned == playerScript)
        {
            newCrowned = _playerScripts[Random.Range(0, _playerScripts.Count)];
        }
        playerScript.UnCrown();
        newCrowned.Crown();
    }

    #endregion
    
    #region Victory Conditions

    public override GameObject[] GetWinners()
    {
        List<GameObject> winners = new List<GameObject>();
        foreach (CrownPlayerScript playerScript in _playerScripts)
        {
            if (playerScript.Crowned)
            {
                winners.Add(playerScript.Player);
            }
        }
        return winners.ToArray();
    }
    public override GameObject[] GetLosers()
    {
        List<GameObject> losers = new List<GameObject>();
        foreach (CrownPlayerScript playerScript in _playerScripts)
        {
            if (!playerScript.Crowned)
            {
                losers.Add(playerScript.Player);
            }
        }
        return losers.ToArray();
    }

    #endregion
}