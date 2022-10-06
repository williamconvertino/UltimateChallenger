using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Player;

public class MainMenuManager : MonoBehaviour
{
    public Button playButton;

    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(StartGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartGame()
    {
        PlayerData testPlayerData = new PlayerData();
        testPlayerData.playerName = "Alex";
        testPlayerData.playerID = 0;
        testPlayerData.playerInputPrefab = Resources.Load<GameObject>("Prefabs/Player/Input/CoopLeftPlayerInput");
        testPlayerData.headSprite = null;
        testPlayerData.spriteColor = Color.red;

        PlayerData testPlayer2Data = new PlayerData();
        testPlayer2Data.playerName = "Aarushi";
        testPlayer2Data.playerID = 0;
        testPlayer2Data.playerInputPrefab = Resources.Load<GameObject>("Prefabs/Player/Input/CoopRightPlayerInput");
        testPlayer2Data.headSprite = null;
        testPlayer2Data.spriteColor = Color.blue;

        PlayerData testPlayer3Data = new PlayerData();
        testPlayer3Data.playerName = "Will";
        testPlayer3Data.playerID = 0;
        testPlayer3Data.playerInputPrefab = Resources.Load<GameObject>("Prefabs/Player/Input/CoopMiddlePlayerInput");
        testPlayer3Data.headSprite = null;
        testPlayer3Data.spriteColor = Color.green;

        GameObject testChallenge = Resources.Load<GameObject>("Prefabs/Challenge/Tag");

        GlobalSettingsSingleton.Instance.ScoringSystemPrefab = Resources.Load<GameObject>("Prefabs/ScoringSystem/PointScoringSystem");
        GlobalSettingsSingleton.Instance.StagePrefab = Resources.Load<GameObject>("Prefabs/Stages/Battlefield");
        GlobalSettingsSingleton.Instance.ChallengePrefabs = new List<GameObject> { testChallenge };
        GlobalSettingsSingleton.Instance.PlayerData = new List<PlayerData> { testPlayerData, testPlayer2Data, testPlayer3Data };
        GlobalSettingsSingleton.Instance.GameTime = 60;
        GlobalSettingsSingleton.Instance.TimeBetweenRounds = 3;


        Scene gameScene = SceneManager.GetSceneByName("Game Scene");
        SceneManager.LoadScene("Game Scene");
    }
}
