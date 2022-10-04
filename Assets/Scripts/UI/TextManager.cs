using System;
using System.Collections;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    public static TextManager instance;
    public TMP_Text bottomGameTitle;
    public TMP_Text bottomGameStatus;
    public TMP_Text screenTitle;
    public TMP_Text screenSubtext;
    public TMP_Text playerName;
    public TMP_Text playerScore;


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

    //Set message
    private void setMessage(TMP_Text textField, string message)
    {
        textField.text = message;
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

    //Setting bottom menu bar messages
    public void setBottomGameStatus(string gameStatus)
    {
        bottomGameStatus.text = gameStatus;
    }

    public void setBottomGameTitle(string gameTitle)
    {
        bottomGameTitle.text = gameTitle;
    }

    //WIP

    //public void setPlayerScore(String playerName, int score)
    //{

    //}

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


}
