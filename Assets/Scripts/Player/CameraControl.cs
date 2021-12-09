using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Camera following script 
//https://github.com/Chaker-Gamra/Endless-Runner-Game/blob/master/Assets/Scripts/Player/CameraController.cs -modified by Lynn Pham
public class CameraControl : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
 
    //position camera behind
    void Start()
    {
        offset = transform.position - target.position;
    }

    //follow player with player tag
    void LateUpdate()
    {
        GetTargetByTag("Player"); 
        Vector3 newPos = new Vector3(transform.position.x,transform.position.y, offset.z+target.position.z);
        transform.position = Vector3.Lerp(transform.position, newPos, 10 * Time.deltaTime);
        //transform.LookAt(target); //camera switches lanes too
    }

    //follow certain target
    void ChangeTarget(Transform _target)
    {
        target = _target;
    }
    //change player target by tag
    void GetTargetByTag(string _tag)
    {
        GameObject obj = GameObject.FindWithTag(_tag);
        if (obj)
        {
            ChangeTarget(obj.transform);
        }
        else
        {
            Debug.Log("Cant find object with tag " + _tag);
        }
    }
}
