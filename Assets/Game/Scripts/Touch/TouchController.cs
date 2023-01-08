using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class TouchController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PlayerControls playerControls;
    [SerializeField] private Camera camPlayer;

    [SerializeField] private InteractScript interactScript;

    private Vector2 curTouch;
    private Vector3 targetRotation;

    [SerializeField] private bool isOrbital = false;
    [SerializeField] private bool isCharaRota = true;

    //public Vector2 touchVector;

    [SerializeField] private float moveSpeed = 5f;

    private float lastMultiTouchDistance;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        playerControls = new PlayerControls();
        playerControls.Player.Enable();

        EnhancedTouchSupport.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isCharaRota)
        {
            if (Touch.activeTouches.Count > 0 && !interactScript.inInteraction)
            {
                if (Touch.activeTouches.Count > 0 && Touch.activeTouches[0].phase == TouchPhase.Began && Touch.activeTouches[0].startScreenPosition.x > Screen.width / 5)
                {
                    interactScript.Interact();
                }
                if (Touch.activeTouches[0].startScreenPosition.x < Screen.width / 5)
                {
                    CharaMove();
                    RaycastHit hit;
                    if (Physics.Raycast(transform.position + new Vector3(0,-0.5f,0), transform.TransformDirection(Vector3.forward), out hit, 3f))
                    {
                        Debug.DrawRay(transform.position + new Vector3(0, -0.5f, 0), transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                        if (hit.distance < 3) 
                        {
                            rb.AddForce(0, 5, 0);
                        }
                    }
                    else
                    {
                        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                    }
                }

                else if (Touch.activeTouches[0].startScreenPosition.x > Screen.width / 5)
                {
                    CharaRota(Touch.activeTouches[0]);
                }

                if (Touch.activeTouches.Count > 1)
                {
                    if (Touch.activeTouches[1].startScreenPosition.x < Screen.width / 5)
                    {
                        CharaMove();
                        RaycastHit hit;
                        if (Physics.Raycast(transform.position + new Vector3(0, -0.5f, 0), transform.TransformDirection(Vector3.forward), out hit, 3f))
                        {
                            Debug.DrawRay(transform.position + new Vector3(0, -0.5f, 0), transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                            if (hit.distance < 3)
                            {
                                rb.AddForce(0, 5, 0);
                            }
                        }
                        else
                        {
                            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                        }
                    }

                    else if (Touch.activeTouches[1].startScreenPosition.x > Screen.width / 5)
                    {
                        CharaRota(Touch.activeTouches[1]);
                    }
                }
            }
        }

        
        if (isOrbital)
        {
            if(Touch.activeTouches.Count == 1)
            {
                MoveOrbital(Touch.activeTouches[0]);
            }
        }
    }

    private void OnInput(Touch touch)
    {
        if (isOrbital)
        {
            if (Touch.activeTouches.Count == 1)
            {
                MoveOrbital(touch);
            }

        }
        if (isCharaRota)
        {
            CharaRota(touch);
        }
    }


private void MoveOrbital (Touch touch)
    {
        //transform.position = modelTransform.position;

        Vector3 curTouchDelta = new Vector3(-1 * touch.delta.normalized.y, touch.delta.normalized.x, 0);

        targetRotation += curTouchDelta * Time.deltaTime * 100;
        
        transform.rotation = Quaternion.Euler(targetRotation);
    }


    private void CharaRota(Touch touch)
    {
        Vector3 curTouchDelta = new Vector3(0, touch.delta.normalized.x, 0);

        targetRotation += curTouchDelta * Time.deltaTime * 100;

        rb.MoveRotation(Quaternion.Euler(targetRotation));
    }

    private void CharaMove()
    {
        Vector2 moveInputVector = playerControls.Player.Move.ReadValue<Vector2>();
        Debug.Log(moveInputVector);

        rb.AddForce(rb.rotation *  new Vector3(moveInputVector.x, 0, moveInputVector.y) * moveSpeed * 5, ForceMode.Force);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, 7f);
    }

}
