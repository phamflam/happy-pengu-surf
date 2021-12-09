using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Author: Lynn Pham
// GameObjects with attractor script automatically get attracted to player
public class Attractor : MonoBehaviour
{
    public float AttractorSpeed=20f;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            transform.position = Vector3.MoveTowards(transform.position, other.transform.position, AttractorSpeed * Time.deltaTime);
        }
    }

    //delete if triggered by player
    private void Update()
    {
        if(transform.childCount < 1)
        {
            Destroy(gameObject);
        }
    }
}
