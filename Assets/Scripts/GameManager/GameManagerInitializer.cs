using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

class GameManagerInitializer : MonoBehaviour
{
    private void Start()
    {
        foreach (PlayerData player in GlobalSettingsSingleton.Instance.PlayerData)
        {
            player.playerInputPrefab = Instantiate(player.playerInputPrefab);
        }

        GameManager.GameSettings gameSettings = new GameManager.GameSettings()
        {
            PlayerData = GlobalSettingsSingleton.Instance.PlayerData,
            ChallengePrefabs = GlobalSettingsSingleton.Instance.ChallengePrefabs,
            GameTime = GlobalSettingsSingleton.Instance.GameTime,
            TimeBetweenRounds = GlobalSettingsSingleton.Instance.TimeBetweenRounds,
            StagePrefab = Instantiate(GlobalSettingsSingleton.Instance.StagePrefab),
            ScoringSystemPrefab = Instantiate(GlobalSettingsSingleton.Instance.ScoringSystemPrefab)
        };
        Instantiate(Resources.Load<GameManager>("Prefabs/GameManager/GameManager"), transform).Init(gameSettings);
    }
}