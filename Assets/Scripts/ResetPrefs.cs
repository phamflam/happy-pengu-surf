using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author: Lynn Pham  
public class ResetPrefs : MonoBehaviour
{
    public void ResetScore()
    {
        PlayerPrefs.SetInt("NumberOfCoins", 0);
        PlayerPrefs.SetInt("AmountCoins", 0);
    }


}
