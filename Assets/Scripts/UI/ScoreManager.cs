using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update

    public TMP_Text scoreText;
    public TMP_Text playerNum;
    public string player;

    int score = 0;

    void Start()
    {
        scoreText.text = score.ToString() + " JUMPS";
        playerNum.text = "PLAYER " + player;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            score++;
            scoreText.text = score.ToString() + " JUMPS";
        }
    }
}
