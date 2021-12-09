using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://github.com/Chaker-Gamra/Endless-Runner-Game/blob/master/Assets/Scripts/Game/AudioManager.cs - modified by Lynn Pham
// Manages Audio -> loop volume, clip
public class AudioManager : MonoBehaviour
{
    private bool isMuted;
    public Sound[] sounds;
    private bool changeSound;
    // Start is called before the first frame update
    void Start()
    {
        isMuted = PlayerPrefs.GetInt("MUTED")==1;
        AudioListener.pause = isMuted;
        

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.isLooped;
            s.source.volume = s.volume;
        }
        //PlaySound("BGM");
        changeSound = false;
        PlaySound("BGM");

        //PlaySound("start"); 
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            changeSound = true;
            if (changeSound)
            {
                PlaySound("BGM2");
            }
            else
            {
                changeSound = false;
                PlaySound("BGM");
            }
        }
    }

    public void PlaySound(string name)
    {
        foreach (Sound s in sounds)
        {
            if(s.name == name)
            {
                s.source.Play();
            }
            if (PauseMenu.GameisPause)
            {
                //s.source.pitch = 0.5f;
                s.source.pitch *= 0.5f;
            }
        }
    }
    // Mute Button functionality
    public void MutePressed()
    {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
        PlayerPrefs.SetInt("MUTED", isMuted ? 1 : 0);
    }
}
