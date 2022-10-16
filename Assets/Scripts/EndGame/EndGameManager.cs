using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Scene gameScene = SceneManager.GetSceneByName("Game Scene");
            SceneManager.LoadScene("Game Scene");
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Scene gameScene = SceneManager.GetSceneByName("Main Menu");
            SceneManager.LoadScene("Main Menu");
        }
    }
}
