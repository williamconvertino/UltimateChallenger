using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

class GameManagerInitWrapper : MonoBehaviour
{

    [Header("Player Settings")]
    [SerializeField] private List<PlayerData> players;
    
    [Header("Challenge Settings")]
    [SerializeField] private List<GameObject> challengePrefabs;

    [Header("Game Settings")]
    [SerializeField] private GameObject stagePrefab;
    [SerializeField] private GameObject scoringSystemPrefab;
    [SerializeField] private float gameTime = Mathf.Infinity;
    [SerializeField] private float timeBetweenRounds = 3;

    private void Start()
    {
        GameManager.GameSettings gameSettings = new GameManager.GameSettings()
        {
            PlayerData = players,
            ChallengePrefabs = challengePrefabs,
            GameTime = gameTime,
            TimeBetweenRounds = timeBetweenRounds,
            StagePrefab = stagePrefab,
            ScoringSystemPrefab = scoringSystemPrefab
        };
        Instantiate(Resources.Load<GameManager>("Prefabs/GameManager/GameManager"), transform).Init(gameSettings);
    }
}