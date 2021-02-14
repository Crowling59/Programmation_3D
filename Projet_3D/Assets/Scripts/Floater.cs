using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    
    public float waterLevel = 0f;
    public float floatThreshold = 2f;
    public float waterDensity = 0.125f;
    public float downForce = 4.0f;

    private float forceFactor;
    private Vector3 floatForce;
    

    // Update is called once per frame
    void FixedUpdate()
    {
        forceFactor = 1f - ((transform.position.y - waterLevel) / floatThreshold);

        if (forceFactor > 0f)
        {
            floatForce = -Physics.gravity * (forceFactor - GetComponent<Rigidbody>().velocity.y * waterDensity);
            floatForce += new Vector3(0f, -downForce, 0f);
            GetComponent<Rigidbody>().AddForceAtPosition(floatForce,transform.position);
        }
    }
}
