
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
          UpdateChallenge();
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

     #region Challenges

     [Header("Challenge Settings")]
     [SerializeField] private GameObject[] challengePrefabs;
     [SerializeField] private float timeBetweenChallenges;
     private GameObject currentChallenge;
     private TimedChallenge currentChallengeScript;

     private void UpdateChallenge()
     {
          if (currentChallengeScript != null && currentChallengeScript.IsChallengeOver)
          {
               StartCoroutine(LoadNewChallenge());
;         }
     }
     
     private IEnumerator LoadNewChallenge()
     {
          if (currentChallenge != null)
          { 
               Destroy(currentChallenge);
               currentChallenge = null;
               currentChallengeScript = null;
          }
          yield return new WaitForSeconds(timeBetweenChallenges);
          print("Starting new challenge");
          currentChallenge = Instantiate(challengePrefabs[Random.Range(0,challengePrefabs.Length)], transform);
          currentChallengeScript = currentChallenge.GetComponent<TimedChallenge>();
          currentChallengeScript.Init(_playerList);
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
