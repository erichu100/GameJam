using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track: MonoBehaviour
{
    public Transform anchor; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraOffset = new Vector3(0, 0, -10);
        transform.position = anchor.position + cameraOffset;
    }
}
