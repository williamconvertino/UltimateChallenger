using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

class GameManagerInitializer : MonoBehaviour
{

    [Header("Player Settings")]
    [SerializeField] private List<PlayerData> players;
    
    [Header("Challenge Settings")]
    [SerializeField] private List<GameObject> challengePrefabs;

    [Header("Game Settings")]
    [SerializeField] private GameObject stagePrefab;
    [SerializeField] private GameObject scoringSystemPrefab;
    [SerializeField] private float gameTime = Mathf.Infinity;
    [SerializeField] private float timeBetweenRounds = 5;

    private void Start()
    {
        GameManager.GameSettings gameSettings = new GameManager.GameSettings()
        {
            PlayerData = GlobalSettingsSingleton.Instance.PlayerData,
            ChallengePrefabs = GlobalSettingsSingleton.Instance.ChallengePrefabs,
            GameTime = GlobalSettingsSingleton.Instance.GameTime,
            TimeBetweenRounds = GlobalSettingsSingleton.Instance.TimeBetweenRounds,
            StagePrefab = GlobalSettingsSingleton.Instance.StagePrefab,
            ScoringSystemPrefab = GlobalSettingsSingleton.Instance.ScoringSystemPrefab
        };
        Instantiate(Resources.Load<GameManager>("Prefabs/GameManager/GameManager"), transform).Init(gameSettings);
    }
}