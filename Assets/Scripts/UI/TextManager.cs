using System;
using System.Collections;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UIElements;

public class TextManager : MonoBehaviour
{
    public static TextManager instance;
    public TMP_Text bottomGameTitle;
    public TMP_Text bottomGameStatus;
    public TMP_Text screenTitle;
    public TMP_Text screenSubtext;
    public TMP_Text playerNameA;
    public TMP_Text playerScoreA;
    public TMP_Text playerNameB;
    public TMP_Text playerScoreB;
    public TMP_Text playerNameC;
    public TMP_Text playerScoreC;
    public TMP_Text playerNameD;
    public TMP_Text playerScoreD;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    //Cleanup 
    private void clearText(TMP_Text textField)
    {
        textField.text = "";
    }

    private void clearPlayer(TMP_Text textField1, TMP_Text textField2)
    {
        textField1.text = "";
        textField2.text = "";
    }

    //Set message
    private void setMessage(TMP_Text textField, string message)
    {
        textField.text = message;
    }

    private void setPlayer(TMP_Text textField1, TMP_Text textField2, string playerName, string playerScore)
    {
        textField1.text = playerName;
        textField2.text = playerScore;
    }

    //Set time message

    public void showMessageForSeconds(TMP_Text textField, String message, float time)
    {
        StartCoroutine(ShowMessageText(textField, message, time));
    }

    IEnumerator ShowMessageText(TMP_Text textField, String message, float time)
    {
        textField.text = message;
        yield return new WaitForSeconds(time);
        clearText(textField);
    }

    //Replacing messages with an empty string

    public void clearScreenTitle()
    {
        clearText(screenTitle);
    }

    public void clearScreenSubtext()
    {
        clearText(screenSubtext);
    }

    public void clearBottomGameStatus()
    {
        clearText(bottomGameStatus);
    }

    public void clearBottomGameTitle()
    {
        clearText(bottomGameTitle);
    }

    public void clearPlayerA()
    {
        clearPlayer(playerNameA, playerScoreA);
    }

    public void clearPlayerB()
    {
        clearPlayer(playerNameB, playerScoreB);
    }

    public void clearPlayerC()
    {
        clearPlayer(playerNameC, playerScoreC);
    }

    public void clearPlayerD()
    {
        clearPlayer(playerNameD, playerScoreD);
    }
    //Setting bottom menu bar messages
    public void setBottomGameStatus(string gameStatus)
    {
        bottomGameStatus.text = gameStatus;
    }

    public void setBottomGameTitle(string gameTitle)
    {
        bottomGameTitle.text = gameTitle;
    }

    //setting player info

    public void setPlayerA(string playerName, string playerScore)
    {
        setPlayer(playerNameA, playerScoreA, playerName, playerScore);
    }

    public void setPlayerB(string playerName, string playerScore)
    {
        setPlayer(playerNameB, playerScoreB, playerName, playerScore);
    }

    public void setPlayerC(string playerName, string playerScore)
    {
        setPlayer(playerNameC, playerScoreC, playerName, playerScore);
    }
    public void setPlayerD(string playerName, string playerScore)
    {
        setPlayer(playerNameD, playerScoreD, playerName, playerScore);
    }
    //Setting screen messages
    public void setScreenTitle(string title)
    {
        screenTitle.text = title;
    }

    public void setScreenSubtext(string subtext)
    {
        screenSubtext.text = subtext;
    }

    //Setting timed screen messages

    public void showTimedScreenTitle(String message, float time)
    {
        showMessageForSeconds(screenTitle, message, time);
    }

    public void showTimedScreenSubtext(String message, float time)
    {
        showMessageForSeconds(screenSubtext, message, time);
    }

    //don't need to update playername everytime
    public void setTextField(string textField, string playerName, int score)
    {
        switch (textField)
        {
            case "A":
                setPlayerA(playerName, score.ToString());
                break;
            case "B":
                setPlayerB(playerName, score.ToString());
                break;
            case "C":
                setPlayerC(playerName, score.ToString());
                break;
            case "D":
                setPlayerD(playerName, score.ToString());
                break;
            default:
                break;
        }
    }

}
