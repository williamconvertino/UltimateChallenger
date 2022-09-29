
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
     #region Core

     private void Start()
     {
          InitializeStage();
          InitializePlayers();
          InitializeGameTimer();
          InitializeRespawnManager();
          InitializeScoringSystem();
          StartCoroutine(LoadNewChallenge());
     }

     private void Update()
     {
          UpdateGameTimer();
          CheckChallengeState();
     }

     #endregion
     
     #region Players

     [Header("Player Settings")] [SerializeField] private GameObject[] playerPrefabs;
     private GameObject[] _playerList;

     private void InitializePlayers()
     {
          _playerList = new GameObject[playerPrefabs.Length];
          for (int i = 0; i < playerPrefabs.Length; i++)
          {
               _playerList[i] = Instantiate(playerPrefabs[i], transform);
          }
     }
     
     
     #endregion

     #region Respawn

     private RespawnManager _respawnManager; 
     private void InitializeRespawnManager()
     {
          _respawnManager = gameObject.AddComponent<RespawnManager>();
          _respawnManager.Init(_playerList, _currentStage);
     }

     #endregion

     #region Load Challenge

     [Header("Challenge Settings")]
     [SerializeField] private GameObject[] challengePrefabs;
     [SerializeField] private float timeBetweenChallenges;
     
     private GameObject currentChallenge;
     private TimedChallenge currentChallengeScript;
     private bool _challengeLoaded = false;
     private IEnumerator LoadNewChallenge()
     {
          yield return new WaitForSeconds(timeBetweenChallenges);
          if (!_isGameOver)
          {
               currentChallenge = Instantiate(challengePrefabs[Random.Range(0,challengePrefabs.Length)], transform);
               currentChallengeScript = currentChallenge.GetComponent<TimedChallenge>();
               currentChallengeScript.Init(_playerList);
               _respawnManager.SetChallenge(currentChallengeScript);
               _challengeLoaded = true;     
          }
     }

     private void UnloadCurrentChallenge()
     {
          if (_challengeLoaded)
          {
               currentChallengeScript.Cleanup();
               Destroy(currentChallenge);
               currentChallenge = null;
               currentChallengeScript = null;
               _challengeLoaded = false;
          }
     }

     #endregion

     #region Challenge State
     private void CheckChallengeState()
     {
          if (!_challengeLoaded || !currentChallengeScript.IsChallengeOver)
          {
               return;
          }

          GameObject[] winners = currentChallengeScript.GetWinners();
          GameObject[] losers = currentChallengeScript.GetLosers();
          scoringSystem.UpdateWinners(winners);
          scoringSystem.UpdateLosers(losers);
          CheckGameState();
          UnloadCurrentChallenge();
          if (!_isGameOver)
          {
               StartCoroutine(LoadNewChallenge());     
          }
     }
     #endregion

     #region Game State

     [Header("Game Settings")]
     [SerializeField] private ScoringSystem scoringSystem;

     private bool _isGameOver = false;
     
     private void CheckGameState()
     {
          if (scoringSystem.IsGameOver())
          {
               EndGame();
          }
     }

     private void EndGame()
     {
          _isGameOver = true;
          Debug.Log("Game winner: ");
          foreach (GameObject player in scoringSystem.GetWinners())
          { 
               Debug.Log(player.GetComponent<PlayerInfo>().GetPlayerName());
          }
     }

     private void InitializeScoringSystem()
     {
          scoringSystem.Init(_playerList);
     }

     #endregion

     #region Game Timer

     [SerializeField] private float totalGameTime = Mathf.Infinity;
     private float _gameTimer;

     private void InitializeGameTimer()
     {
          _gameTimer = totalGameTime;
     }
     private void UpdateGameTimer()
     {
          _gameTimer -= Time.deltaTime;
          if (_gameTimer <= 0 && !_isGameOver && !_challengeLoaded)
          {
               EndGame();
          }
     }

     #endregion
     
     #region Stage

     [Header("Stage Settings")]
     [SerializeField] private GameObject stage;

     private GameObject _currentStage;

     private void InitializeStage()
     {
          _currentStage = Instantiate(stage, transform);
     }

     #endregion

}
