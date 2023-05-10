using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boingSound : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void Play()
    {
        audio.Play();
    }

}
