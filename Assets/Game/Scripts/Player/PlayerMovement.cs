using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 rawInputMovement;

    [SerializeField] float mvtSpeed = 10f;

    Vector2 moveInput;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //      MOVEMENT
        /*
        float moveSpeed = 4;
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

            CameraOffset = camTurnAngle * CameraOffset;
        }
            */

        //      MOVEMENT WITHOUT NEW INPUT MANAGER
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
       

        if (Input.GetKey(KeyCode.Q))
        {
            rb.AddTorque(-TorqueSpeed * transform.up);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(TorqueSpeed * transform.up);
        }*/

        //      MOVEMENT WITH NEW INPUTMANAGER
        Run();
    }
    /*private void OnMovement(InputAction.CallbackContext value)
    {
        Vector2 inputMovement = value.ReadValue<Vector2>();
        rawInputMovement = new Vector3(inputMovement.x, 0, inputMovement.y);
    }*/

    private void Run()
    {
        Vector3 playerVelocity = new Vector3(moveInput.x * mvtSpeed, rb.velocity.y, moveInput.y * mvtSpeed);
        rb.velocity = transform.TransformDirection(playerVelocity);
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}
