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

    public GameObject PlayerOneSpriteSelector;
    public GameObject PlayerTwoSpriteSelector;
    public GameObject PlayerOneSprite;
    public GameObject PlayerTwoSprite;

    public TMP_Text SelectedStageName;

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

        GameObject tagChallenge = Resources.Load<GameObject>("Prefabs/Challenge/Tag");
        GameObject crownChallenge = Resources.Load<GameObject>("Prefabs/Challenge/Crown");
        GameObject dartChallenge = Resources.Load<GameObject>("Prefabs/Challenge/DartHunt");
        GameObject snakeChallenge = Resources.Load<GameObject>("Prefabs/Challenge/Snake");
        GameObject hopperChallenge = Resources.Load<GameObject>("Prefabs/Challenge/Hopper_02");

        GlobalSettingsSingleton.Instance.ScoringSystemPrefab = Resources.Load<GameObject>("Prefabs/ScoringSystem/PointScoringSystem");
        GlobalSettingsSingleton.Instance.ChallengePrefabs = new List<GameObject> { tagChallenge, crownChallenge, dartChallenge, snakeChallenge, hopperChallenge };

        ShiftPlayerSprite(0, 0);
        ShiftPlayerSprite(1, 0);
        ShiftSelectedStage(0);
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

    public void ShiftPlayerSprite(int playerID, int shift)
    {
        GlobalSettingsSingleton.Instance.ShiftPlayerSprite(playerID, shift);
        PlayerOneSprite.GetComponent<SpriteRenderer>().color = GlobalSettingsSingleton.Instance.PlayerData[0].spriteColor;
        PlayerTwoSprite.GetComponent<SpriteRenderer>().color = GlobalSettingsSingleton.Instance.PlayerData[1].spriteColor;
        PlayerOneSpriteSelector.GetComponent<SpriteRenderer>().color = GlobalSettingsSingleton.Instance.PlayerData[0].spriteColor;
        PlayerTwoSpriteSelector.GetComponent<SpriteRenderer>().color = GlobalSettingsSingleton.Instance.PlayerData[1].spriteColor;
    }

    public void ShiftSelectedStage(int shift)
    {
        GlobalSettingsSingleton.Instance.ShiftStage(shift);
        SelectedStageName.text = GlobalSettingsSingleton.Instance.StageName;
    }
}
