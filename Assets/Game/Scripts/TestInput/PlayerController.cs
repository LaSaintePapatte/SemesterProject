using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerInput playerInput;
    private PlayerControls playerControls;

    private Vector2 startPos;
    private Vector2 deltaPos;
    public Vector2 touchVector;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        playerControls = new PlayerControls();
        playerControls.Player.Enable();
        playerControls.Player.Interact.performed += Interact;

        EnhancedTouchSupport.Enable();


        //Touch.onFingerDown += Touch_onFingerDown;



    }

    private void Touch_onFingerDown(Finger obj)
    {
        startPos = obj.screenPosition;
    }

    private void getDelta(Finger obj)
    {
        deltaPos = obj.screenPosition - startPos;
    }

    private void Update()
    {
        



        ///////////// MOVEMENT /////////////
        //Vector2 moveInputVector = playerControls.Player.Move.ReadValue<Vector2>();

        ////float speed = 20f;
        ////rb.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * speed, ForceMode.Force);

        //float moveSpeed = 5f;
        ////Define the speed at which the object moves.

        //transform.Translate(new Vector3(moveInputVector.x, 0, moveInputVector.y) * moveSpeed * Time.deltaTime);


       
       

        touchVector = playerControls.Player.Look.ReadValue<Vector2>();

        //Debug.Log(touchVector);
        //Debug.Log(playerControls.Player.Look);
    }



    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed) 
        {
            Debug.Log("Interacting");
        }
        
    }

    private void Babar()
    {
            
    }


    ////Movement variables
    //[SerializeField] float moveSpeed = 10f;
    //public Rigidbody rb;

    //Vector2 moveDirection = Vector2.zero;
    //private InputAction move;
    //private InputAction interact;

    //private PlayerControls playerControls;

    //private void Awake()
    //{
    //    playerControls = new PlayerControls();
    //}

    //private void OnEnable()
    //{
    //    move = playerControls.Player.Move;
    //    move.Enable();

    //}

    //private void OnDisable()
    //{
    //    move.Disable();
    //}

    //private void Start()
    //{

    //}

    //private void Update()
    //{
    //    moveDirection = move.ReadValue<Vector2>();
    //    Debug.Log(move);
    //    //playerControls.Player.Interact.ReadValue<float>();
    //    //if (playerControls.Player.Interact.ReadValue<float>() == 1)
    //    if (playerControls.Player.Interact.triggered)
    //    {
    //        Debug.Log("Interacting");
    //    }
    //}

    //public void Move()
    //{
    //    Vector3 playerVelocity = new Vector3(moveDirection.x * moveSpeed, 0, moveDirection.y * moveSpeed);
    //    rb.velocity = transform.TransformDirection(playerVelocity);
    //}
}
