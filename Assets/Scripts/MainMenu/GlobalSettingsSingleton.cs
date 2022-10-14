using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSettingsSingleton : MonoBehaviour
{
    public static GlobalSettingsSingleton Instance { get; private set; }

    public List<PlayerData> PlayerData;
    public List<GameObject> ChallengePrefabs;
    public GameObject ScoringSystemPrefab;
    public GameObject StagePrefab;
    public float GameTime;
    public float TimeBetweenRounds;
    public string WinnerName;
    public int NumWinners;

    private Color[] PossibleColors = new Color[] { Color.red, Color.blue, Color.cyan, Color.green, Color.yellow, Color.magenta };

    // Start is called before the first frame update
    void Start()
    {
        PlayerData testPlayerData = new PlayerData();
        testPlayerData.playerName = "Player1";
        testPlayerData.playerID = 0;
        testPlayerData.playerInputPrefab = Resources.Load<GameObject>("Prefabs/Player/Input/CoopLeftPlayerInput");
        testPlayerData.headSprite = null;
        testPlayerData.spriteColor = Color.red;

        PlayerData testPlayer2Data = new PlayerData();
        testPlayer2Data.playerName = "Player2";
        testPlayer2Data.playerID = 1;
        testPlayer2Data.playerInputPrefab = Resources.Load<GameObject>("Prefabs/Player/Input/CoopRightPlayerInput");
        testPlayer2Data.headSprite = null;
        testPlayer2Data.spriteColor = Color.blue;

        GlobalSettingsSingleton.Instance.PlayerData = new List<PlayerData> { testPlayerData, testPlayer2Data };
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ShiftPlayerSprite(int playerID, int shift)
    {
        foreach (PlayerData player in this.PlayerData)
        {
            if (player.playerID == playerID)
            {
                int previousColorIndex = Array.IndexOf(PossibleColors, player.spriteColor);
                player.spriteColor = PossibleColors[(previousColorIndex + shift) % PossibleColors.Length];
                return;
            }
        }
    }
}
