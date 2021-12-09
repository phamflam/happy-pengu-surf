using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// rotates object 
// Author: Lynn Pham
public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 50;
    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);

    }
}
