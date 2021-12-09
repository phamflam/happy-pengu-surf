using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// magnet trigger for coins to get attracted to player
// Author: Lynn Pham
public class Magnet : MonoBehaviour
{
    private GameObject coinDetectorObj;

    // Start is called before the first frame update
    void Start()
    {
        coinDetectorObj = GameObject.FindGameObjectWithTag("CoinDetector");
        coinDetectorObj.SetActive(false);
    }

    // magnet gets triggered by player on collison
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ActivateCoin());
            Destroy(transform.GetChild(0).gameObject);
        }

    }
    
    // coin gets attracted if activated 
    IEnumerator ActivateCoin()
    {
        coinDetectorObj.SetActive(true);
        yield return new WaitForSeconds(6f);
        coinDetectorObj.SetActive(false);
    }
}
