using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// applied on jump pads
// author: Lynn Pham
// no need because player can already jump
public class Jumpboost : MonoBehaviour
{
    [Range(100, 1000)]
    public float bounceheight;
    public Rigidbody rigidPlayer;
    private Rigidbody rigid;

    //private void OnTriggerEnter(Collider other)
    //{
    //    other.GetComponent<Rigidbody>().AddForce(Vector3.up * bounceheight);
    //}

    private void Start()
    {
        rigid = transform.GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        //GameObject player = collision.gameObject;
        //Rigidbody rb = player.GetComponent<Rigidbody>();
        //rb.AddForce(Vector3.up * bounceheight);
        if (collision.transform.tag == "Player")
        {
            rigidPlayer.velocity = transform.up * bounceheight;
        }
    }
}
