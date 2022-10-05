using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class TagChallenge : TimedChallenge
{
    #region Initialization
    
    private List<TagPlayerScript> _playerScripts;
    public override void Init(GameObject[] players)
    {
        base.Init(players);
        AddScriptToPlayers<TagPlayerScript>();
        _playerScripts = GetPlayerScripts<TagPlayerScript>();
        TagPlayerScript initialTagger = _playerScripts[Random.Range(0,_playerScripts.Count)];
        initialTagger.Tag();
        TextManager.instance.showTimedScreenTitle("Starting Tag", 5);
        TextManager.instance.setBottomGameTitle("Playing: Tag");
        Debug.Log("Starting Tag");
    }
    #endregion

    #region On Respawn

    public override void OnPlayerRespawn(GameObject player)
    {
        foreach (TagPlayerScript playerScript in _playerScripts)
        {
            if (playerScript.Player == player)
            {
                playerScript.Tag();
            }
            else
            {
                playerScript.UnTag();
            }
        }
    }

    #endregion
    
    #region Victory Conditions

    public override GameObject[] GetWinners()
    {
        List<GameObject> winners = new List<GameObject>();
        foreach (TagPlayerScript playerScript in _playerScripts)
        {
            if (!playerScript.Tagged)
            {
                winners.Add(playerScript.Player);
            }
        }
        Debug.Log(winners.ToArray());
        return winners.ToArray();
    }
    public override GameObject[] GetLosers()
    {
        List<GameObject> losers = new List<GameObject>();
        foreach (TagPlayerScript playerScript in _playerScripts)
        {
            if (playerScript.Tagged)
            {
                losers.Add(playerScript.Player);
            }
        }
        return losers.ToArray();
    }

    #endregion
}