using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSoundController : MonoBehaviour
{
    AudioSource audioSource;
    public float minPitch = 0;
    private float pitchFromCar;
    CarController controller;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = minPitch;
        controller = GetComponent<CarController>();
    }

    // Update is called once per frame
    void Update()
    {
        pitchFromCar = controller.GetCurrentSpeed() * 0.08f;
        if (pitchFromCar < minPitch)
            audioSource.pitch = minPitch;
        else
            audioSource.pitch = pitchFromCar;

 
    }
}
