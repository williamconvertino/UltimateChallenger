using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneLeftToggle : MonoBehaviour
{
    public GameObject MainMenuManager;

    private void OnMouseDown()
    {
        MainMenuManager.GetComponent<MainMenuManager>().ShiftPlayerSprite(0, -1);
    }
}
