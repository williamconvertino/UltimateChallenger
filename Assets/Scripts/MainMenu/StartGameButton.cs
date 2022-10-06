using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    private void OnMouseDown()
    {
        Scene gameScene = SceneManager.GetSceneByName("Game Scene");
        SceneManager.LoadScene("Game Scene");
    }
}
