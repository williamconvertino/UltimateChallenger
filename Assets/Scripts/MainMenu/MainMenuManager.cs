using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Player;
using TMPro;
using System;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager Instance { get; private set; }

    public Camera mainCamera;

    private int[] PossibleTotalTimes = new int[] { 15, 30, 45, 60, 90, 120, 180 };
    private int TotalTimeIndex = 3;
    public TMP_Text TotalTimeValueLabel;

    private int[] PossibleTimeBetweenRounds = new int[] { 2, 3, 4, 5, 6, 7, 8 };
    private int TimeBetweenRoundsIndex = 3;
    public TMP_Text TimeBetweenRoundsValueLabel;

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
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateTimeDisplay();
        UpdateTimeBetweenRoundsDisplay();

        PlayerData testPlayerData = new PlayerData();
        testPlayerData.playerName = "Player1";
        testPlayerData.playerID = 0;
        testPlayerData.playerInputPrefab = Resources.Load<GameObject>("Prefabs/Player/Input/CoopLeftPlayerInput");
        testPlayerData.headSprite = null;
        testPlayerData.spriteColor = Color.red;

        PlayerData testPlayer2Data = new PlayerData();
        testPlayer2Data.playerName = "Player2";
        testPlayer2Data.playerID = 0;
        testPlayer2Data.playerInputPrefab = Resources.Load<GameObject>("Prefabs/Player/Input/CoopRightPlayerInput");
        testPlayer2Data.headSprite = null;
        testPlayer2Data.spriteColor = Color.blue;

        GameObject tagChallenge = Resources.Load<GameObject>("Prefabs/Challenge/Tag");
        GameObject crownChallenge = Resources.Load<GameObject>("Prefabs/Challenge/Crown");
        GameObject dartChallenge = Resources.Load<GameObject>("Prefabs/Challenge/DartHunt");
        GameObject snakeChallenge = Resources.Load<GameObject>("Prefabs/Challenge/Snake");
        GameObject hopperChallenge = Resources.Load<GameObject>("Prefabs/Challenge/Hopper_02");

        GlobalSettingsSingleton.Instance.ScoringSystemPrefab = Resources.Load<GameObject>("Prefabs/ScoringSystem/PointScoringSystem");
        GlobalSettingsSingleton.Instance.StagePrefab = Resources.Load<GameObject>("Prefabs/Stages/CrazyCastle");
        GlobalSettingsSingleton.Instance.ChallengePrefabs = new List<GameObject> { tagChallenge, crownChallenge, dartChallenge, snakeChallenge, hopperChallenge };
        GlobalSettingsSingleton.Instance.PlayerData = new List<PlayerData> { testPlayerData, testPlayer2Data };

        //TODO need options to change stage, maybe challenges
    }

    public void IncrementTime()
    {
        if (TotalTimeIndex < PossibleTotalTimes.Length - 1)
        {
            TotalTimeIndex++;
        }
        UpdateTimeDisplay();
    }

    public void DecrementTime()
    {
        if (TotalTimeIndex > 0)
        {
            TotalTimeIndex--;
        }
        UpdateTimeDisplay();
    }

    private void UpdateTimeDisplay()
    {
        TotalTimeValueLabel.text = PossibleTotalTimes[TotalTimeIndex].ToString();
        GlobalSettingsSingleton.Instance.GameTime = PossibleTotalTimes[TotalTimeIndex];
    }

    public void IncrementTimeBetweenRounds()
    {
        if (TimeBetweenRoundsIndex < PossibleTimeBetweenRounds.Length - 1)
        {
            TimeBetweenRoundsIndex++;
        }
        UpdateTimeBetweenRoundsDisplay();
    }

    public void DecrementTimeBetweenRounds()
    {
        if (TimeBetweenRoundsIndex > 0)
        {
            TimeBetweenRoundsIndex--;
        }
        UpdateTimeBetweenRoundsDisplay();
    }

    private void UpdateTimeBetweenRoundsDisplay()
    {
        TimeBetweenRoundsValueLabel.text = PossibleTimeBetweenRounds[TimeBetweenRoundsIndex].ToString();
        GlobalSettingsSingleton.Instance.TimeBetweenRounds = PossibleTimeBetweenRounds[TimeBetweenRoundsIndex];
    }

    public void MoveCameraNext()
    {
        Vector3 previous = mainCamera.transform.position;
        mainCamera.transform.position = new Vector3(previous.x + 18, previous.y, previous.z);
    }

    internal void MoveCameraPrevious()
    {
        Vector3 previous = mainCamera.transform.position;
        mainCamera.transform.position = new Vector3(previous.x - 18, previous.y, previous.z);
    }
}
