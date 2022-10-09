
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;
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
          _challengeFrequencies = new Dictionary<GameObject, int>();
          foreach (GameObject challengePrefab in _challengePrefabs)
          {
               _challengeFrequencies[challengePrefab] = 0;
          }
          InitializeStage();
          InitializePlayers();
          InitializeCamera();
          InitializeGameTimer();
          InitializeRespawnManager();
          InitializeScoringSystem();
          StartCoroutine(LoadNewChallenge());
          _initialized = true;
          TextManager.instance.showTimedScreenTitle("Welcome to Ultimate Challenger", 3);
        TextManager.instance.clearScreenSubtext();
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

     private GameObject _dynamicCamera;
     private void InitializeCamera()
     {
          _dynamicCamera = Instantiate(Resources.Load<GameObject>("Prefabs/Camera/DynamicCamera"));
          _dynamicCamera.GetComponent<DynamicCamera>().Init(_playerList);
     }

     #region Respawn

     private RespawnManager _respawnManager; 
     private void InitializeRespawnManager()
     {
          _respawnManager = gameObject.AddComponent<RespawnManager>();
          _respawnManager.Init(_playerList, _defaultStage);
     }

     #endregion

     #region Load Challenge

     [Header("Challenge Settings")]
     private List<GameObject> _challengePrefabs;
     private float _timeBetweenChallenges;

     private Dictionary<GameObject, int> _challengeFrequencies;

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
               TextManager.instance.setScreenTitle("New game in: " + ((int)_gameSettings.TimeBetweenRounds - timeWaited).ToString());
           
          }
          if (!_isGameOver)
          {

               List<GameObject> possibleChallenges = new List<GameObject>();
               int minChallengeFreq = 99999;
               foreach (GameObject challengePrefab in _challengePrefabs)
               {
                    if (_challengeFrequencies[challengePrefab] < minChallengeFreq)
                    {
                         minChallengeFreq = _challengeFrequencies[challengePrefab];
                         possibleChallenges.Clear();
                    }

                    if (_challengeFrequencies[challengePrefab] == minChallengeFreq)
                    {
                         possibleChallenges.Add(challengePrefab);
                    }
               }

               GameObject chosenPrefab = possibleChallenges[Random.Range(0, possibleChallenges.Count)];
               currentChallenge = Instantiate(chosenPrefab, transform);

               _challengeFrequencies[chosenPrefab]++;
               currentChallengeScript = currentChallenge.GetComponent<Challenge>();
               currentChallengeScript.InitStageHandlers((stage) => SetStage(stage), () => ResetStage());
               currentChallengeScript.Init(_playerList.ToArray(), _defaultStage);
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

     private void SetStage(Stage stage)
     {
          _defaultStage.gameObject.SetActive(false);
          _respawnManager.SetStage(stage);
     }
     
     private void ResetStage()
     {
          _defaultStage.gameObject.SetActive(true);
          _respawnManager.SetStage(_defaultStage);
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
        //TextManager.instance.showTimedScreenSubtext("Winner(s) " + String.Join(", ", String.Join(", ", winners)), 2);
        _scoringSystem.PrintScores();
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
          //UIManager.instance.gameStatus(_isGameOver);
          SceneManager.LoadScene("Ending");

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

     private Stage _defaultStage;

     private void InitializeStage()
     {
          _defaultStage = Instantiate(_gameSettings.StagePrefab, transform).GetComponent<Stage>();
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
