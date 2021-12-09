using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//playermanagement for several panels/canvases
// https://github.com/Chaker-Gamra/Endless-Runner-Game/blob/master/Assets/Scripts/Player/PlayerManager.cs - modified by Lynn Pham
public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;
    public static bool isStarted;
    public GameObject startingText;
    public static int numberSpats;
    public bool IsDead;
    public TextMeshProUGUI numberSpatsTxt;
    public static int score=0;
    //public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI highScoreTxt;
    public GameObject PauseBtn;

    void Start()
    {   
        isStarted = false;
        gameOver = false;
        IsDead = false;
        Time.timeScale = 1;
        numberSpats = 0;
        highScoreTxt.text = "Best Spat-Score\n" + PlayerPrefs.GetInt("NumberOfCoins", 0);
        PauseBtn.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //numberSpatsTxt.text = PlayerPrefs.GetInt("NumberOfCoins", 0).ToString(); //save
        if (gameOver)
        {
            IsDead = true;
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            PauseBtn.SetActive(false);

            //if (score> PlayerPrefs.GetInt("NumberOfCoins", 0))
            //{
            //    PlayerPrefs.SetInt("NumberOfCoins", score);
            //}
            //score = 0;
            if (numberSpats > PlayerPrefs.GetInt("NumberOfCoins", 0))
            {
                PlayerPrefs.SetInt("NumberOfCoins", numberSpats);
                highScoreTxt.text = "New Best Spat-Score\n" + PlayerPrefs.GetInt("NumberOfCoins", 0);
            }
            //NumberSpats = 0; //set number of spats to zero when game is over to start by 0 again
            Debug.Log("spatsnr: " + numberSpats);
            Debug.Log("coinamount " + PlayerPrefs.GetInt("AmountCoins", 0));
            Debug.Log("highscore " + PlayerPrefs.GetInt("NumberOfCoins", 0));

            //PlayerPrefs.SetInt("AmountCoins", PlayerPrefs.GetInt("AmountCoins", 0) + numberSpats); //
        }

        if (SwipeManager.tap)
        {
            isStarted = true;
            Destroy(startingText);

        }
        numberSpatsTxt.text = ""+ numberSpats.ToString();
        //scoreTxt.text = score.ToString();
    }

}
