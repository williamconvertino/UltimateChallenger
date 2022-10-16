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
    public string StageName;

    private Color[] PossibleColors;
    private Dictionary<int, int> PlayerIDToColorIndex;

    private string[] PossibleStages;
    private string[] PossibleStageNames;
    private int SelectedStageIndex;

    private int NumPlayers;

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

            PossibleColors = new Color[] { new Color(0.4291207f, 0.7256108f, 0.7924528f, 1f), Color.red, Color.green, Color.cyan, Color.magenta, Color.grey };
            PlayerIDToColorIndex = new Dictionary<int, int>();
            PlayerIDToColorIndex.Add(0, 0);
            PlayerIDToColorIndex.Add(1, 1);
            PlayerIDToColorIndex.Add(2, 2);

            PossibleStages = new string[] { "Battlefield", "CrazyCastle" };
            PossibleStageNames = new string[] { "Battlefield", "Crazy Castle" };
            SelectedStageIndex = 0;
            StageName = PossibleStageNames[SelectedStageIndex];

            GlobalSettingsSingleton.Instance.StagePrefab = Resources.Load<GameObject>(("Prefabs/Stages/" + PossibleStages[SelectedStageIndex]));

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

            PlayerData testPlayer3Data = new PlayerData();
            testPlayer3Data.playerName = "Player3";
            testPlayer3Data.playerID = 2;
            testPlayer3Data.playerInputPrefab = Resources.Load<GameObject>("Prefabs/Player/Input/CoopMiddlePlayerInput");
            testPlayer3Data.headSprite = null;
            testPlayer3Data.spriteColor = PossibleColors[PlayerIDToColorIndex[2]];

            GlobalSettingsSingleton.Instance.PlayerData = new List<PlayerData> { testPlayerData, testPlayer2Data, testPlayer3Data };

            GameObject tagChallenge = Resources.Load<GameObject>("Prefabs/Challenge/Tag");
            GameObject crownChallenge = Resources.Load<GameObject>("Prefabs/Challenge/Crown");
            GameObject dartChallenge = Resources.Load<GameObject>("Prefabs/Challenge/DartHunt");
            GameObject snakeChallenge = Resources.Load<GameObject>("Prefabs/Challenge/Snake");
            GameObject hopperChallenge = Resources.Load<GameObject>("Prefabs/Challenge/Hopper_02");

            GlobalSettingsSingleton.Instance.ScoringSystemPrefab = Resources.Load<GameObject>("Prefabs/ScoringSystem/PointScoringSystem");
            GlobalSettingsSingleton.Instance.ChallengePrefabs = new List<GameObject> { tagChallenge, crownChallenge, dartChallenge, snakeChallenge, hopperChallenge };

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

    public void ShiftStage(int shift)
    {
        SelectedStageIndex = SelectedStageIndex + shift;
        if (SelectedStageIndex < 0)
        {
            SelectedStageIndex = PossibleStages.Length - 1;
        }
        SelectedStageIndex = SelectedStageIndex % PossibleStages.Length;
        GlobalSettingsSingleton.Instance.StagePrefab = Resources.Load<GameObject>(("Prefabs/Stages/" + PossibleStages[SelectedStageIndex]));
        StageName = PossibleStageNames[SelectedStageIndex];
    }
}
