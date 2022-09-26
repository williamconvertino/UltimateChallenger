using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Minigames;

public class GameManager : MonoBehaviour
{

    [Header("Stage info")]
    //The main stage of the game.
    [SerializeField] private GameObject mainStage;
    [SerializeField] private GameObject[] players;

    [Header("Minigames")]
    //Stores GameObjects with all the possible minigames.
    //minigames_nocoop represents games that are not compatible with coop mode.
    [SerializeField] private Minigame[] minigames;
    [SerializeField] private Minigame[] minigames_nocoop;

    //The active stage.
    private Minigame currentMinigame;

    //Switches the current minigame to be the given stage.
    public void SwitchMinigame(Minigame minigame)
    {
        if (currentMinigame != null)
        {
            Destroy(currentMinigame);   
        }
        currentMinigame = Instantiate(minigame);
        currentMinigame.Initialize(players);
    }
    
}
