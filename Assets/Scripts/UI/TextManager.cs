using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun.Demo.PunBasics;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    public static TextManager instance;
    public TMP_Text titleText;
    public TMP_Text timer;

    int score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void showTitleForSeconds(String message, float time)
    {
        StartCoroutine(ShowTitleText(message, time));
    }
    
    public void showTitle(String message)
    {
        titleText.text = message;
    }

    IEnumerator ShowTitleText(String message, float time)
    {
        titleText.text = message;
        yield return new WaitForSeconds(time);
        titleText.text = "";
    }
    // Start is called before the first frame update
    void Start()
    {
        //showTitleForSeconds("Welcome to the game", 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
