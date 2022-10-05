using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

class GameManagerInitializer : MonoBehaviour
{
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