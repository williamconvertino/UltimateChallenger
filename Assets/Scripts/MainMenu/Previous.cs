using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Previous : MonoBehaviour
{
    private void OnMouseDown()
    {
        MainMenuManager.Instance.MoveCameraPrevious();
    }
}
