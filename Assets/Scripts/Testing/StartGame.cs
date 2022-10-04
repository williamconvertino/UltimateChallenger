using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(OnButtonPress);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnButtonPress()
    {
        print("hi i'm pressed");
    }
}
