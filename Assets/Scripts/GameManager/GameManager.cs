using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{

    [Header("Players")]
    [SerializeField] private GameObject[] players;
    
    [Header("Challenges")]
    [SerializeField] private GameObject[] challenges;
    [SerializeField] private float challengeDelay;
    
    private GameObject _currentChallenge;
    private Challenge _currentChallengeScript;
    private float challengeDelayTimer;

    private void Start()
    {
        foreach (GameObject player in players)
        {
            RespawnManager.GlobalPlayerList.Add(player);   
        }
    }

    private void Update()
    {
        UpdateCurrentChallenge();
    }

    #region Challenges
    private void UpdateCurrentChallenge()
    {
        if (_currentChallengeScript != null && _currentChallengeScript.IsChallengeOver)
        {
            Destroy(_currentChallenge);
            SetNewChallenge();
        }
    }

    private void SetNewChallenge()
    {
        _currentChallenge = Instantiate(challenges[Random.Range(0,challenges.Length)]);
        _currentChallengeScript = _currentChallenge.GetComponent<Challenge>();
        _currentChallengeScript.Init(players);
    }
    #endregion
    
}
