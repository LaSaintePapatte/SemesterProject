using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;

    [SerializeField] AnimationCurve accelerationCam;

    private float targetAngle = 0f;

    public float MvtSpeed = 100f;
    public float TorqueSpeed = 20f;

    private Vector3 targetRotation;

    [SerializeField]
    float acceleration = 1f;

    
    private Vector3 mouseDelta;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKey(KeyCode.Z))
        {
            rb.AddForce(MvtSpeed * transform.forward);
        }

        

        if (Input.GetKey(KeyCode.Q))
        {
            //targetRotation = rb.rotation.eulerAngles + new Vector3(0,-TorqueSpeed,0);
            targetAngle = Mathf.Lerp(targetAngle, -TorqueSpeed, 0.1f) ;

            //rb.rotation = Quaternion.Lerp(rb.rotation, targetRotation, accelerationCam.Evaluate(0.5f));
        }

        if (Input.GetKey(KeyCode.D))
        {
            //targetRotation = rb.rotation.eulerAngles + new Vector3(0, TorqueSpeed, 0);
            targetAngle = Mathf.Lerp(targetAngle, TorqueSpeed, 0.1f);

        }
        if (!Input.GetKey(KeyCode.Q) && !Input.GetKey(KeyCode.D))
        {
            targetAngle = Mathf.Lerp(targetAngle, 0, 0.005f);
        }


            targetRotation = rb.rotation.eulerAngles + new Vector3(0, targetAngle, 0);


        Quaternion _newRot = Quaternion.Slerp(rb.rotation, Quaternion.Euler(targetRotation), acceleration * Time.deltaTime);

        rb.MoveRotation(_newRot);


        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-MvtSpeed * transform.forward);
        }
       */

        
        float moveSpeed = 4 ;
        //Define the speed at which the object moves.

        float horizontalInput = Input.GetAxis("Horizontal");
        //Get the value of the Horizontal input axis.

        float verticalInput = Input.GetAxis("Vertical");
        //Get the value of the Vertical input axis.

        transform.Translate(new Vector3(horizontalInput, 0, verticalInput) * moveSpeed * Time.deltaTime);



        if (Input.GetMouseButton(0))
        {
            mouseDelta = new Vector3(0, Input.GetAxis("Mouse X"), 0); // 

            targetRotation += mouseDelta * Time.deltaTime * 100;

            rb.MoveRotation(Quaternion.Euler(targetRotation * 3));

            /*Quaternion camTurnAngleX = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, Vector3.up);
            Quaternion camTurnAngleZ = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * RotationSpeed, Vector3.up);
            
            CameraOffset = camTurnAngle * CameraOffset;*/
        }



        /*
        if (Input.GetKey(KeyCode.Q))
        {
            rb.AddTorque(-TorqueSpeed * transform.up);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(TorqueSpeed * transform.up);
        }*/
    }

    
}
