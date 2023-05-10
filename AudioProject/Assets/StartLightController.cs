using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLightController : MonoBehaviour
{
    public List<GameObject> lights;

    // Start is called before the first frame update
    void Start()
    {
        for (int ligth = 0; ligth < lights.Count; ligth++)
        {
            lights[ligth].GetComponent<MeshRenderer>().material.color = Color.black;
        }  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
