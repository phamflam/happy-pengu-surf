using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// pause menu manager 
// Author: Lynn Pham
public class PauseMenu : MonoBehaviour
{
    public static bool GameisPause = false;
    public GameObject pauseMenuUI;
    private bool isPressed = false;
    public GameObject PauseBtn;

    //check if mute button is pressed
    void Update()
    {
        if (isPressed)
        {
            if (GameisPause)
            {
                Resume();
               
            }
            else
            {
                Pause();
                isPressed = false;
            }
        }
    }

    // resumes game
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPause = false;
        PauseBtn.SetActive(true);
    }
    
    //pauses game
    public void Pause()
    {
        isPressed = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPause = true;
        PauseBtn.SetActive(false);
    }
}
