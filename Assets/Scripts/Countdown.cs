using System.Collections;
using UnityEngine.UI;
using UnityEngine;

// Author: Lynn Pham
// count the time left for item duration
public class Countdown : MonoBehaviour
{
    private bool count;
    float currentTime = 0f;
    float startingTime = 10f; // -> from activiateCoin()
    public Text countdownText;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        currentTime = startingTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //countDown(); 
            count = true;
            Debug.Log("triggered "+count.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("updated " + count.ToString());
        if (count)
        {
            countDown();
        }
        //countDown();
        
    }

    private void countDown()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime == 3)
        {
            countdownText.color = Color.red;
        }

        if (currentTime <= 0)
        {
            currentTime = 0;
        }
    }
}
