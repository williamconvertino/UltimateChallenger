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

    private Color[] PossibleColors;
    private Dictionary<int, int> PlayerIDToColorIndex;

    // Start is called before the first frame update
    void Start()
    {
        
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

            PossibleColors = new Color[] { Color.red, new Color(0.4291207f, 0.7256108f, 0.7924528f, 1f), Color.cyan, Color.green, Color.magenta, Color.grey };
            PlayerIDToColorIndex = new Dictionary<int, int>();
            PlayerIDToColorIndex.Add(0, 0);
            PlayerIDToColorIndex.Add(1, 1);
            PlayerIDToColorIndex.Add(2, 2);

            PlayerData testPlayerData = new PlayerData();
            testPlayerData.playerName = "Player1";
            testPlayerData.playerID = 0;
            testPlayerData.playerInputPrefab = Resources.Load<GameObject>("Prefabs/Player/Input/CoopLeftPlayerInput");
            testPlayerData.headSprite = null;
            testPlayerData.spriteColor = PossibleColors[PlayerIDToColorIndex[0]];

            PlayerData testPlayer2Data = new PlayerData();
            testPlayer2Data.playerName = "Player2";
            testPlayer2Data.playerID = 1;
            testPlayer2Data.playerInputPrefab = Resources.Load<GameObject>("Prefabs/Player/Input/CoopRightPlayerInput");
            testPlayer2Data.headSprite = null;
            testPlayer2Data.spriteColor = PossibleColors[PlayerIDToColorIndex[1]];

            GlobalSettingsSingleton.Instance.PlayerData = new List<PlayerData> { testPlayerData, testPlayer2Data };
        }
    }

    public void ShiftPlayerSprite(int playerID, int shift)
    {
        foreach (PlayerData player in this.PlayerData)
        {
            if (player.playerID == playerID)
            {
                int previousColorIndex = PlayerIDToColorIndex[playerID];
                if (previousColorIndex == 0 && shift == -1)
                {
                    player.spriteColor = PossibleColors[PossibleColors.Length - 1];
                    PlayerIDToColorIndex[playerID] = PossibleColors.Length - 1;
                } else
                {
                    player.spriteColor = PossibleColors[(previousColorIndex + shift) % PossibleColors.Length];
                    PlayerIDToColorIndex[playerID] = previousColorIndex + shift % PossibleColors.Length;
                }
                return;
            }
        }
    }
}
