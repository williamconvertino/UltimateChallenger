using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoRightToggle : MonoBehaviour
{
    public GameObject MainMenuManager;

    private void OnMouseDown()
    {
        MainMenuManager.GetComponent<MainMenuManager>().ShiftPlayerSprite(1, 1);
    }
}
