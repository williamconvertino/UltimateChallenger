
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Player;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
     #region Core

     private bool _initialized;
     private GameSettings _gameSettings;
     public void Init(GameSettings settings)
     {
          _gameSettings = settings;
          _challengePrefabs = settings.ChallengePrefabs;
          _scoringSystem = Instantiate(settings.ScoringSystemPrefab).GetComponent<ScoringSystem>();
          totalGameTime = settings.GameTime;
          InitializeStage();
          InitializePlayers();
          InitializeGameTimer();
          InitializeRespawnManager();
          InitializeScoringSystem();
          StartCoroutine(LoadNewChallenge());
          _initialized = true;
          TextManager.instance.showTimedScreenTitle("Welcome to the game", 3);
        TextManager.instance.clearScreenSubtext();
          TextManager.instance.setPlayerA("Player 3", "Wins: 0");
        TextManager.instance.setPlayerB("Player 2", "Wins: 0");
          TextManager.instance.setPlayerC("Player 1", "Wins: 0");
        TextManager.instance.clearPlayerD();
    }

     private void Update()
     {
          if (!_initialized)
          {
               return;
          }
          UpdateGameTimer();
          CheckChallengeState();
     }

     #endregion
     
     #region Players

     [Header("Player Settings")]
     private List<GameObject> _playerList;

     private void InitializePlayers()
     {
          _playerList = new List<GameObject>();
          int currentPlayerID = 0;
          foreach (PlayerData pd in _gameSettings.PlayerData)
          {
               GameObject player = Instantiate(Resources.Load<GameObject>("Prefabs/Player/Player"));
               player.AddComponent(pd.playerInputPrefab.GetComponent<PlayerInput>().GetType());
               player.GetComponent<SpriteRenderer>().color = pd.spriteColor;
               PlayerInfo playerInfo = player.AddComponent<PlayerInfo>();
               playerInfo.playerName = pd.playerName;
               playerInfo.playerID = pd.playerID;
               _playerList.Add(player);
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
     private List<GameObject> _challengePrefabs;
     private float _timeBetweenChallenges;
     
     private GameObject currentChallenge;
     private Challenge currentChallengeScript;
     private bool _challengeLoaded = false;
     private IEnumerator LoadNewChallenge()
     {
          float timeWaited = 0;
          while (timeWaited < _gameSettings.TimeBetweenRounds)
          {
               timeWaited += 1;
               yield return new WaitForSeconds(1);
               TextManager.instance.setScreenTitle(((int)_gameSettings.TimeBetweenRounds - timeWaited).ToString());
           
          }
          if (!_isGameOver)
          {
            
            currentChallenge = Instantiate(_challengePrefabs[Random.Range(0,_challengePrefabs.Count)], transform);
               currentChallengeScript = currentChallenge.GetComponent<Challenge>();
               currentChallengeScript.Init(_playerList.ToArray());
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
          _scoringSystem.UpdateWinners(winners);
          _scoringSystem.UpdateLosers(losers);
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
     private ScoringSystem _scoringSystem;

     private bool _isGameOver = false;
     
     private void CheckGameState()
     {
          if (_scoringSystem.IsGameOver())
          {
               EndGame();
          }
     }

     private void EndGame()
     {
          if (_isGameOver)
          {
            return;
          }
          _isGameOver = true;
        

          Debug.Log("------------\n Scores:\n------------");
          _scoringSystem.PrintScores();

     }

     private void InitializeScoringSystem()
     {
          _scoringSystem.Init(_playerList.ToArray());
     }

     #endregion

     #region Game Timer

     private float totalGameTime = Mathf.Infinity;
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

     private GameObject _currentStage;

     private void InitializeStage()
     {
          _currentStage = Instantiate(_gameSettings.StagePrefab, transform);
     }

     #endregion

     public struct GameSettings
     {
          public List<PlayerData> PlayerData;
          public List<GameObject> ChallengePrefabs;
          public GameObject ScoringSystemPrefab;
          public GameObject StagePrefab;
          public float GameTime;
          public float TimeBetweenRounds;
          
     }
     
}
