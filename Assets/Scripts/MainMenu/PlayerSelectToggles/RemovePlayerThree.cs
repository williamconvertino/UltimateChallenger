using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovePlayerThree : MonoBehaviour
{
    public GameObject MainMenuManager;

    private void OnMouseDown()
    {
        MainMenuManager.GetComponent<MainMenuManager>().RemovePlayerThree();
    }
}
