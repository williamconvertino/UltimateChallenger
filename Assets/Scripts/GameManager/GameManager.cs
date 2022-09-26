
using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
     #region Core

     private void Start()
     {
          InitializeStage();
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

     #endregion

     #region Respawn

     private RespawnManager _respawnManager; 
     private void InitializeRespawnManager()
     {
          _respawnManager = gameObject.AddComponent<RespawnManager>();
          _respawnManager.Init(playerPrefabs, _currentStage);
     }

     #endregion

     #region Challenges

     [Header("Challenge Settings")]
     [SerializeField] private GameObject[] challengePrefabs;
     [SerializeField] private float timeBetweenChallenges;
     private GameObject currentChallenge;
     private Challenge currentChallengeScript;

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
          currentChallenge = Instantiate(challengePrefabs[Random.Range(0,challengePrefabs.Length)]);
          currentChallengeScript = currentChallenge.GetComponent<Challenge>();
          currentChallengeScript.Init(playerPrefabs);
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
