using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// author: Lynn Pham
// sound attributes
[System.Serializable]
public class Sound {
    public string name;
    public AudioClip clip;
    public float volume;
    public bool isLooped;

    public AudioSource source;
}
