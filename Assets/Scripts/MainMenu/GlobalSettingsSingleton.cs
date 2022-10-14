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
    private int PlayerOneColorIndex = 0;
    private int PlayerTwoColorIndex = 1;

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
