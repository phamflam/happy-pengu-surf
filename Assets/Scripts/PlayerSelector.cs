using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// shop management
// Author: Lynn Pham 
public class PlayerSelector : MonoBehaviour
{
    public GameObject[] players;
    public int currentModelIdx;

    // get selected player and set it to active
    void Start()
    {
        currentModelIdx = PlayerPrefs.GetInt("SelectedPlayer", 0);
        foreach (GameObject player in players)
        {
            player.SetActive(false);
        }
        players[currentModelIdx].SetActive(true);
    }
}
