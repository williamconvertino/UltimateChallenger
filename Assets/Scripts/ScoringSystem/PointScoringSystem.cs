using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Player;

public class PointScoringSystem : ScoringSystem
{
    [SerializeField] private int pointsToWin = 9999;
    private int _highestScore = 0;
    private Dictionary<GameObject, int> _playerScore;
    private Dictionary<GameObject, string> playerToTextField;
    private List<string> playersInTheLead;
    private string[] textFields = { "A", "B", "C", "D" };

    public override void Init(GameObject[] players)
    {
        base.Init(players);
        _playerScore = new Dictionary<GameObject, int>();
        playerToTextField = new Dictionary<GameObject, string>();
        playersInTheLead = new List<string>();

        TextManager.instance.clearPlayerA();
        TextManager.instance.clearPlayerB();
        TextManager.instance.clearPlayerC();
        TextManager.instance.clearPlayerD();

        int textFieldIterator = 0;
        foreach (GameObject player in players)
        {
            _playerScore.Add(player, 0);
            playerToTextField.Add(player, textFields[textFieldIterator]);
            TextManager.instance.setTextField(textFields[textFieldIterator], player.GetComponent<PlayerInfo>().playerName, 0);
            textFieldIterator++;
        }

        TextManager.instance.setBottomGameStatus("In the lead: ");
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
        playersInTheLead.Clear();
        foreach (GameObject player in Players)
        {
            Debug.Log(player.GetComponent<PlayerInfo>().playerName + ": " + _playerScore[player] + " points.");
            TextManager.instance.setTextField(playerToTextField[player], player.GetComponent<PlayerInfo>().playerName, _playerScore[player]);
            if (_playerScore[player] == _highestScore)
            {
                playersInTheLead.Add(player.GetComponent<PlayerInfo>().playerName);
            }
        }
        TextManager.instance.setBottomGameStatus("In the lead: " + String.Join(", ", playersInTheLead));
    }

    public void UpdateScores()
    {
        foreach (GameObject player in Players)
        {
            TextManager.instance.setTextField(playerToTextField[player], player.GetComponent<PlayerInfo>().playerName, _playerScore[player]);
        }
    }
}
