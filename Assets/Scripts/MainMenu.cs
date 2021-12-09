using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// switch scenes 
// Author: Lynn Pham
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void OpenStore()
    {
        SceneManager.LoadScene(2);
    }
    public void OpenMenu()
    {
        SceneManager.LoadScene(0);
    }
}
