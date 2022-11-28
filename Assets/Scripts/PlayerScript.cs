using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;


    public float MvtSpeed = 100f;
    public float TorqueSpeed = 20f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            rb.AddForce(MvtSpeed * transform.forward);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-MvtSpeed * transform.forward);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            rb.AddTorque(-TorqueSpeed * transform.up);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(TorqueSpeed * transform.up);
        }
    }
}
