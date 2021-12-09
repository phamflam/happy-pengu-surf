using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://github.com/Chaker-Gamra/Endless-Runner-Game/blob/master/Assets/Scripts/Tiles/Gem.cs - modified by Lynn Pham
// manages Coinrotation, collected coins
public class Coin : MonoBehaviour
{
    public Transform playerTransform;
    public float moveSpeed = 20f;

    CoinMove coinMS;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        coinMS = gameObject.GetComponent<CoinMove>();
    }

    // rotate coin
    void Update()
    {
        transform.Rotate(50 * Time.deltaTime, 0, 0);
    }

    // collision with player increases spatcount
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<AudioManager>().PlaySound("collect");
            PlayerManager.numberSpats++;
            //PlayerManager.score++;
            Destroy(gameObject);
            //PlayerPrefs.SetInt("AmountCoins", PlayerPrefs.GetInt("AmountCoins", 0) + PlayerManager.numberSpats); //
            PlayerPrefs.SetInt("AmountCoins", PlayerPrefs.GetInt("AmountCoins", 0) + 1);
        }
        // Magnet functionality whenever Coin enters coin
        if (other.gameObject.CompareTag("CoinDetector"))
        {
            coinMS.enabled = true;
        }
    }
}
