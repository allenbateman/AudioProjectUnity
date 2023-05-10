using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashTrigger : MonoBehaviour
{
    CarController controller;
    AudioSource crashSound;
    public float threshold;
    // Start is called before the first frame update
    void Start()
    {
        crashSound = GetComponent<AudioSource>();
        controller = transform.parent.GetComponent<CarController>();

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            if (controller.GetCurrentSpeed() > threshold)
            {
                //crash
                Debug.Log("wall collsion");
                crashSound.Play();
            }

        }
    }
}
