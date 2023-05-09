using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    private Rigidbody rb;
    private Transform tr;
    public float speed = 20;
    public float rotationSpeed = 20;
    public float maxVelocity  = 50;
    private Quaternion newRotation;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (rb.velocity.magnitude < maxVelocity)
                rb.velocity += tr.forward * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.S))
        {    

            if(rb.velocity.magnitude > -maxVelocity )
                rb.velocity -= tr.forward * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.D))
        {
            
            transform.Rotate(rotationSpeed * tr.up * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(rotationSpeed * -tr.up * Time.deltaTime);
        }
    }
    public float GetCurrentSpeed()
    {
        return rb.velocity.magnitude;
    }
}
