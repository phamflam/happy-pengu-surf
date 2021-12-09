using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// author: Lynn Pham
// manages events/ switches scenes
public class Events : MonoBehaviour
{
   public void ReplayGame()
    {
        SceneManager.LoadScene("Level");
        
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
