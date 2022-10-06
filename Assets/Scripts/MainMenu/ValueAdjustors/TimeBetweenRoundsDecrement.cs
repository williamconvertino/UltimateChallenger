using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBetweenRoundsDecrement : MonoBehaviour
{
    private void OnMouseDown()
    {
        MainMenuManager.Instance.DecrementTimeBetweenRounds();
    }
}
