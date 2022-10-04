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

    void showTitleForSeconds()
    {
        titleText.text = "Welcome to the game";
    }
    // Start is called before the first frame update
    void Start()
    {
        showTitleForSeconds();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
