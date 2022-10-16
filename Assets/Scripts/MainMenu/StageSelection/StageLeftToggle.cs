using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageLeftToggle : MonoBehaviour
{
    public GameObject MainMenuManager;

    private void OnMouseDown()
    {
        MainMenuManager.GetComponent<MainMenuManager>().ShiftSelectedStage(-1);
    }
}
