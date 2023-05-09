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


        Debug.Log(1 - dot);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "wall")
        {
            if(controller.speed > 35)
            {
                //crash
            }
            //crash
        }
    }
}
