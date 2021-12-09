using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//author: Lynn Pham
public class SwitchMusicTrigger : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip1;
    public AudioClip clip2;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = clip1;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            if (audioSource.clip == clip1)
            {
                audioSource.clip = clip2;
                audioSource.Play();
            }
            else
            {
                audioSource.clip = clip1;
                audioSource.Play();
            }
        }
    }
}
