using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class RPSChallenge : TimedChallenge
{
    #region Initialization

    private List<RPSPlayerScript> _playerScripts;
    private Dictionary<RPSTeam, int> _teamScores;
    private RPSTeam[] _allTeams = new RPSTeam[] { RPSTeam.Paper , RPSTeam.Rock, RPSTeam.Scissors};
    public override void Init(GameObject[] players, Stage stage)
    {
        base.Init(players, stage);
        _playerScripts = AddScriptToPlayers<RPSPlayerScript>();
        _teamScores = new Dictionary<RPSTeam, int>();
        foreach (RPSTeam team in new[] { RPSTeam.Rock, RPSTeam.Paper, RPSTeam.Scissors }) {
            _teamScores.Add(team, 0);
        }
        
        PopulateTeams();
        TextManager.instance.showTimedScreenTitle("Rock, Paper, Scissors", 5);
        TextManager.instance.setBottomGameTitle("Rock, Paper, Scissors");
        Debug.Log("Starting RPS");
    }

    private void PopulateTeams()
    {
        List<RPSTeam> remainingTeams = new List<RPSTeam>(_allTeams);
        
        foreach (RPSPlayerScript playerScript in _playerScripts)
        {
            if (remainingTeams.Count == 0)
            {
                remainingTeams = new List<RPSTeam>(remainingTeams);
            }

            RPSTeam team = remainingTeams[Random.Range(0, remainingTeams.Count)];
            remainingTeams.Remove(team);
            playerScript.SetTeam(team);
            playerScript.SetAddScoreFunction(() => _teamScores[team]++);
        }
    }
    
    #endregion

    #region On Respawn

    public override void OnPlayerRespawn(GameObject player)
    {
        RPSPlayerScript playerScript = player.GetComponent<RPSPlayerScript>();
        playerScript.Hit();
        foreach (RPSTeam team in _allTeams)
        {
            if (team != playerScript.Team)
            {
                _teamScores[team]++;
            }
        }
    }

    #endregion
    
    #region Victory Conditions
    public override GameObject[] GetWinners()
    {
        List<GameObject> winners = new List<GameObject>();
        int maxScore = _teamScores.Values.Max();
        foreach (RPSPlayerScript playerScript in _playerScripts)
        {
            if (_teamScores[playerScript.Team] == maxScore)
            {
                winners.Add(playerScript.Player);
            }
        }
        
        return winners.ToArray();
    }
    public override GameObject[] GetLosers()
    {
        List<GameObject> losers = new List<GameObject>();
        int maxScore = _teamScores.Values.Max();
        foreach (RPSPlayerScript playerScript in _playerScripts)
        {
            if (_teamScores[playerScript.Team] != maxScore)
            {
                losers.Add(playerScript.Player);
            }
        }
        
        return losers.ToArray();
    }

    #endregion

    public enum RPSTeam
    {
        Rock,
        Paper,
        Scissors
    }
}