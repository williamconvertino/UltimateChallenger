
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
     #region Core

     private void Start()
     {
          InitializeStage();
          InitializePlayers();
          InitializeRespawnManager();
          StartCoroutine(LoadNewChallenge());
     }

     private void Update()
     {
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

     #region Challenge Initialization

     [Header("Challenge Settings")]
     [SerializeField] private GameObject[] challengePrefabs;
     [SerializeField] private float timeBetweenChallenges;
     
     private GameObject currentChallenge;
     private TimedChallenge currentChallengeScript;
     private bool challengeLoaded = false;
     private IEnumerator LoadNewChallenge()
     {
          if (challengeLoaded)
          { 
               Destroy(currentChallenge);
               currentChallenge = null;
               currentChallengeScript = null;
          }
          yield return new WaitForSeconds(timeBetweenChallenges);
          currentChallenge = Instantiate(challengePrefabs[Random.Range(0,challengePrefabs.Length)], transform);
          currentChallengeScript = currentChallenge.GetComponent<TimedChallenge>();
          currentChallengeScript.Init(_playerList);
          challengeLoaded = true;
     }

     #endregion

     #region Challenge State
     private void CheckChallengeState()
     {
          if (!challengeLoaded || !currentChallengeScript.IsChallengeOver)
          {
               return;
          }

          GameObject[] winners = currentChallengeScript.GetWinners();
          GameObject[] losers = currentChallengeScript.GetLosers();
          Debug.Log("Winner:\n");
          foreach (GameObject player in winners)
          {
               Debug.Log(player.GetComponent<PlayerInfo>().name);
          }
          StartCoroutine(LoadNewChallenge());
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
