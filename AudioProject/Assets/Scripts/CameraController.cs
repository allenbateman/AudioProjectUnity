using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void LateUpdate()
    {
        float desiredAngle = target.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);

        float dist = Vector3.Distance(transform.position,target.position + offset);
        
        transform.position =  Vector3.Slerp(transform.position, target.position - (rotation * offset), dist);
        
        transform.LookAt(target.transform);
    }
}
