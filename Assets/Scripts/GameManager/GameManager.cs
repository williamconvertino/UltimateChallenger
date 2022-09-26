using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
     #region Core

     private void Start()
     {
          InitializeStage();
          InitializeRespawnManager();
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

     [Header("Challenge Settings")] [SerializeField] private GameObject[] challengePrefabs;

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
