using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Next : MonoBehaviour
{
    private void OnMouseDown()
    {
        MainMenuManager.Instance.MoveCameraNext();
    }
}
