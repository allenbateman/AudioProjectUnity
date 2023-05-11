using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public AudioClip music;
    public AudioSource Audio;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (Audio.clip == music)
                return;
            Audio.clip = music;
            Audio.Play();
        }
    }
}
