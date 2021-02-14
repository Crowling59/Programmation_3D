using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoatController : MonoBehaviour
{

    public float turnSpeed = 150f;
    public float accellerateSpeed = 1800f;
    
    private Rigidbody rbody;
    private BoostTemplate boostTemplate;
    

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        rbody.AddTorque(0f,h*turnSpeed*Time.deltaTime,0f);
        rbody.AddForce(-transform.forward*v*accellerateSpeed*Time.deltaTime);

        //Detect when the down arrow key is pressed down
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Down Arrow key was pressed.");
            accellerateSpeed = 900f;
        }
        
        //Detect when the down arrow key has been released
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            Debug.Log("Down Arrow key was released.");
            accellerateSpeed = 1800f;
        }
        
    }
    
}
