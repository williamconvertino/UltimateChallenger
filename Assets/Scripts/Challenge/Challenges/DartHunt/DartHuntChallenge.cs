using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class DartHuntChallenge : Challenge
{
    #region Initialization
    
    private List<DartHuntPlayerScript> _playerScripts;
    private List<Dart> _activeDarts;
    public override void Init(GameObject[] players)
    {
        base.Init(players);
        AddScriptToPlayers<DartHuntPlayerScript>();
        _playerScripts = GetPlayerScripts<DartHuntPlayerScript>();
        _activeDarts = new List<Dart>();
        foreach (DartHuntPlayerScript playerScript in _playerScripts)
        {
            playerScript.SetSpawnDartFunction((GameObject dart) =>
            {
                _activeDarts.Add(dart.GetComponent<Dart>());
                return true;
            });
        }
        TextManager.instance.showTimedScreenTitle("Starting Dart Hunt", 5);
        TextManager.instance.setBottomGameTitle("Playing: Dart Hunt");
        Debug.Log("Starting Dart Hunt");
    }
    #endregion

    #region Update

    private void Update()
    {
        CheckVictory();
        CheckDarts();
    }

    private void CheckDarts()
    {
        List<Dart> deadDarts = new List<Dart>();
        foreach (Dart dart in _activeDarts)
        {
            if (dart.DartHit)
            {
                deadDarts.Add(dart);
            }
        }

        foreach (Dart dart in deadDarts)
        {
            _activeDarts.Remove(dart);
            Destroy(dart.gameObject);
        }
    }

    #endregion

    #region On Respawn

    public override void OnPlayerRespawn(GameObject player)
    {
        DartHuntPlayerScript playerScript = player.GetComponent<DartHuntPlayerScript>();
        playerScript.Hit();
    }

    #endregion
    
    #region Victory Conditions

    protected override void CheckVictory()
    {
        int playersRemaining = 0;
        foreach (DartHuntPlayerScript playerScript in _playerScripts)
        {
            if (!playerScript.PlayerHit)
            {
                playersRemaining++;
            }
        }

        if (playersRemaining == 1)
        {
            IsChallengeOver = true;
        }
    }

    public override GameObject[] GetWinners()
    {
        List<GameObject> winners = new List<GameObject>();
        foreach (DartHuntPlayerScript playerScript in _playerScripts)
        {
            if (!playerScript.PlayerHit)
            {
                winners.Add(playerScript.Player);
            }
        }

        return winners.ToArray();
    }
    public override GameObject[] GetLosers()
    {
        List<GameObject> losers = new List<GameObject>();
        foreach (DartHuntPlayerScript playerScript in _playerScripts)
        {
            if (playerScript.PlayerHit)
            {
                losers.Add(playerScript.Player);
            }
        }

        return losers.ToArray();
    }

    #endregion
}