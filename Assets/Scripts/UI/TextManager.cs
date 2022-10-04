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
    // Start is called before the first frame update
    void Start()
    {
        titleText.text = "TEST TITLE TAG";
        timer.text = "Time left ";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
