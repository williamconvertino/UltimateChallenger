using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneRightToggle : MonoBehaviour
{
    public GameObject MainMenuManager;

    private void OnMouseDown()
    {
        MainMenuManager.GetComponent<MainMenuManager>().ShiftPlayerSprite(0, 1);
    }
}
