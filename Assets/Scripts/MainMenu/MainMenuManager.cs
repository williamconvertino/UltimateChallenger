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
        GlobalSettingsSingleton.Instance.PlayerData = null;
        GlobalSettingsSingleton.Instance.ChallengePrefabs = null;
        GlobalSettingsSingleton.Instance.GameTime = 0;
        GlobalSettingsSingleton.Instance.TimeBetweenRounds = 0;
        GlobalSettingsSingleton.Instance.StagePrefab = null;
        GlobalSettingsSingleton.Instance.ScoringSystemPrefab = null;

        PlayerData testPlayerData = new PlayerData();

        Scene gameScene = SceneManager.GetSceneByName("Game Scene");
        SceneManager.LoadScene("Game Scene");

        GameObject player = Instantiate(Resources.Load<GameObject>("Prefabs/Player/Player"));


        player.GetComponent<SpriteRenderer>().color = Color.red;
        player.AddComponent<PlayerInfo>().playerName = "Alex";
        Vector2 position = new Vector2(0,0);
        player.transform.position = position;
        player.SetActive(true);
        print("can you see this");
    }
}
