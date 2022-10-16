using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThreeRightToggle : MonoBehaviour
{
    public GameObject MainMenuManager;

    private void OnMouseDown()
    {
        MainMenuManager.GetComponent<MainMenuManager>().ShiftPlayerSprite(2, 1);
    }
}
