using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// script for coinattractor triggered by magnet 
// Author Lynn Pham
public class CoinMove : MonoBehaviour
{
    Coin coinS;
    // Start is called before the first frame update
    void Start()
    {
        coinS = gameObject.GetComponent<Coin>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, coinS.playerTransform.position, coinS.moveSpeed * Time.deltaTime);
    }

    //the coin gets destroyed when entering player
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerBubble")
        {
            Destroy(gameObject);
        }
    }

}
