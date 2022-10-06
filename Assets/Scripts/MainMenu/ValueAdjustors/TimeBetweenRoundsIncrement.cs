using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBetweenRoundsIncrement : MonoBehaviour
{
    private void OnMouseDown()
    {
        MainMenuManager.Instance.IncrementTimeBetweenRounds();
    }
}
