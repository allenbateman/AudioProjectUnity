using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSoundController : MonoBehaviour
{
    AudioSource engineSound;
    public float minPitch = 0;
    private float pitchFromCar;
    CarController controller;
    public AudioSource driftSound;
    public AudioSource crashSound;
    // Start is called before the first frame update
    void Start()
    {
        engineSound = GetComponent<AudioSource>();
        engineSound.pitch = minPitch;
        controller = GetComponent<CarController>();
        driftSound.volume = 0;
        driftSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        pitchFromCar = controller.GetCurrentSpeed() * 0.08f;
        if (pitchFromCar < minPitch)
            engineSound.pitch = minPitch;
        else
            engineSound.pitch = pitchFromCar;

        DriftSound();
    }

    void DriftSound()
    {
        if (controller.GetCurrentSpeed() < 35)
        {
            driftSound.volume = 0;
            return;
        }

        float dot = Vector3.Dot(controller.transform.forward.normalized, controller.GetComponent<Rigidbody>().velocity.normalized);

        if (dot > 1)
            dot = 1;

        driftSound.volume = (1 - dot) * 1.6f;
        driftSound.pitch =  1 + driftSound.volume * 0.3f;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            if(controller.GetCurrentSpeed() > 35)
            {
                //crash
                Debug.Log("wall collsion");
                crashSound.Play();
            }

        }
    }
}
