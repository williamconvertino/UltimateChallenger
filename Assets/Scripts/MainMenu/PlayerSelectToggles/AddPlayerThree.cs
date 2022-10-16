using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPlayerThree : MonoBehaviour
{
    public GameObject MainMenuManager;

    private void OnMouseDown()
    {
        MainMenuManager.GetComponent<MainMenuManager>().AddPlayerThree();
    }
}
