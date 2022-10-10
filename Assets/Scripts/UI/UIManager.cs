using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text winnerText;
    [SerializeField] private TMP_Text restartText;
    //public string currentWinnerName;
    public bool isGameOver = false;

    public static UIManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        //Disables panel if active
        if (GlobalSettingsSingleton.Instance.NumWinners >1)
        {
            winnerText.text = "It's a Tie: " + GlobalSettingsSingleton.Instance.WinnerName;
        }
        if (GlobalSettingsSingleton.Instance.NumWinners == 1)
        {
            winnerText.text = "Winner: " + GlobalSettingsSingleton.Instance.WinnerName;
        }
        
        winnerText.gameObject.SetActive(true);
        gameOverPanel.SetActive(true);
        restartText.gameObject.SetActive(true);
    }
    // Update is called once per frame
    //void Update()
    //{
    //    //Trigger game over manually and check with bool so it isn't called multiple times
    //    if (Input.GetKeyDown(KeyCode.Q) || !isGameOver)
    //    {
    //        isGameOver = true;
    //        updateWinner();
    //        StartCoroutine(GameOverSequence());
    //    }

    //    //If game is over
    //    if (isGameOver)
    //    {
    //        //If R is hit, restart the current scene
    //        if (Input.GetKeyDown(KeyCode.R))
    //        {
    //            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //        }

    //        ////If Q is hit, quit the game
    //        //if (Input.GetKeyDown(KeyCode.Q))
    //        //{
    //        //    print("Application Quit");
    //        //    Application.Quit();
    //        //}
    //    }
    //}

    //controls game over canvas and there's a brief delay between main Game Over text and option to restart/quit text
    private IEnumerator GameOverSequence()
    {
        gameOverPanel.SetActive(true);
        winnerText.gameObject.SetActive(true);

        yield return new WaitForSeconds(5.0f);

        restartText.gameObject.SetActive(true);

    }

}
