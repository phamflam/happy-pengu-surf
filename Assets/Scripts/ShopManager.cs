using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
// manages shop GUI
// https://github.com/Chaker-Gamra/Endless-Runner-Game/blob/master/Assets/Scripts/Store/ShopManager.cs - modified by Lynn Pham
public class ShopManager : MonoBehaviour
{
    public GameObject[] playerModels;
    public int currentModelIdx;
    public Player[] players;
    public Button buyBtn;
    public TextMeshProUGUI numberSavedCoins;

    // Start is called before the first frame update
    void Start()
    {
        numberSavedCoins.GetComponentInChildren<TextMeshProUGUI>().text = PlayerPrefs.GetInt("AmountCoins", 0).ToString(); //

        foreach (Player play in players)
        {
            if (play.price == 0)
            {
                play.isUnlocked = true;
            }
            else
            {
                play.isUnlocked = PlayerPrefs.GetInt(play.name, 0)==0 ? false: true;
            }
        }

        currentModelIdx = PlayerPrefs.GetInt("SelectedPlayer", 0);
        foreach (GameObject player in playerModels  ) {
            player.SetActive(false);
        }
        playerModels[currentModelIdx].SetActive(true);

        UpdateUI();
    }

    //void Update()
    //{
    //    UpdateUI();
    //}
    public void ChangeNext()
    {
        playerModels[currentModelIdx].SetActive(false);

        currentModelIdx++;
        if (currentModelIdx == playerModels.Length) {
            currentModelIdx = 0;

        }
        playerModels[currentModelIdx].SetActive(true);

        UpdateUI();

        Player p = players[currentModelIdx];
        if (!p.isUnlocked)
        {
            return;
        }

        PlayerPrefs.SetInt("SelectedPlayer", currentModelIdx);
    }
    public void ChangePrev()
    {
        playerModels[currentModelIdx].SetActive(false);

        currentModelIdx--;
        if (currentModelIdx == -1)
        {
            currentModelIdx = playerModels.Length -1;

        }
        playerModels[currentModelIdx].SetActive(true);

        UpdateUI();

        Player p = players[currentModelIdx];
        if (!p.isUnlocked)
        {
            return;
        }

        PlayerPrefs.SetInt("SelectedPlayer", currentModelIdx);
    }
    public void UnlockPlayer()
    {
        Player p = players[currentModelIdx];

        PlayerPrefs.SetInt(p.name, 1);
        PlayerPrefs.SetInt("SelectedPlayer", currentModelIdx);
        p.isUnlocked = true;
        PlayerPrefs.SetInt("AmountCoins", PlayerPrefs.GetInt("AmountCoins", 0) - p.price);
        /*
                PlayerBlueprint p = players[currentModelIdx];
                if (PlayerPrefs.GetInt("NumberOfCoins", 0) < p.price)
                    return;

                int newCoins = PlayerPrefs.GetInt("NumberOfCoins", 0) - players[currentModelIdx].price;
                PlayerPrefs.SetInt("NumberOfCoins", newCoins);

                p.isUnlocked = true;
                PlayerPrefs.SetInt(p.name, 0);
                PlayerPrefs.SetInt("NumberOfCoins", currentModelIdx);

                UpdateUI();
        */
        UpdateUI();

    }
    private void UpdateUI()
    {
        numberSavedCoins.GetComponentInChildren<TextMeshProUGUI>().text = PlayerPrefs.GetInt("AmountCoins", 0).ToString();
        Player p = players[currentModelIdx];

        if (p.isUnlocked)
        {
            buyBtn.gameObject.SetActive(false);
        }
        else
        {
            buyBtn.gameObject.SetActive(true);
            buyBtn.GetComponentInChildren<TextMeshProUGUI>().text = "Buy-" + p.price;
            if (p.price < PlayerPrefs.GetInt("AmountCoins", 0))
            {
                buyBtn.interactable = true;
            }
            else
            {
                buyBtn.interactable = false;
            }
        }
        /*
        if (!p.isUnlocked)
        {
            buyBtn.gameObject.SetActive(true);
            buyBtn.GetComponentInChildren<TextMeshProUGUI>().text = p.price + "";

            if (PlayerPrefs.GetInt("NumberOfCoins", 0) < p.price)
                buyBtn.interactable = false;
            else
                buyBtn.interactable = true;
        }
        else
        {
         buyBtn.gameObject.SetActive(false);
        }
        */
    }

}
