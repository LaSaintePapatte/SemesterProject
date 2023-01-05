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
            //CharaMove();

            if (Touch.activeTouches.Count > 0)
            {
                


                if (Touch.activeTouches.Count > 0 && Touch.activeTouches[0].phase == TouchPhase.Began)
                {
                    interactScript.Interact();
                }
                if (Touch.activeTouches[0].startScreenPosition.x < Screen.width / 5)
                {
                    CharaMove();
                    RaycastHit hit;
                    if (Physics.Raycast(transform.position + new Vector3(0,-0.5f,0), transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
                    {
                        Debug.DrawRay(transform.position + new Vector3(0, -0.5f, 0), transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                        //Debug.Log("Did Hit");
                        if (hit.distance < 3) 
                        {
                            rb.AddForce(0, 5, 0);
                        }
                    }
                    else
                    {
                        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                    //    Debug.Log("Did not Hit");
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


    //private void Interact()
    //{
    //    Ray ray = camPlayer.ScreenPointToRay(Touch.activeTouches[0].screenPosition);
    //    RaycastHit hit;


    //    if (Physics.Raycast(ray, out hit))
    //    {
    //        if (hit.collider != null)
    //        {
    //            if (hit.collider.gameObject.CompareTag("House"))
    //            {
    //                SceneManager.LoadScene("S_Castrum");
    //            }
    //        }
    //    }
    //}

    private void OnInput(Touch touch)
    {
        if (isOrbital)
        {
            if (Touch.activeTouches.Count == 1)
            {
                MoveOrbital(touch);
            }
            else if (Touch.activeTouches.Count == 2)
            {
                ZoomCamera(Touch.activeTouches[0], Touch.activeTouches[1]);
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

        //transform.Translate(new Vector3(moveInputVector.x, 0, moveInputVector.y) * moveSpeed * Time.deltaTime);
        rb.AddForce(rb.rotation *  new Vector3(moveInputVector.x, 0, moveInputVector.y) * moveSpeed * 5);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, 7f);
    }

    private void ZoomCamera(Touch firstTouch, Touch secondTouch)
    {
        //1
        if (firstTouch.phase == TouchPhase.Began || secondTouch.phase == TouchPhase.Began)
        {
            lastMultiTouchDistance = Vector2.Distance(firstTouch.screenPosition, secondTouch.screenPosition);
        }
        //2
        if (firstTouch.phase != TouchPhase.Moved || secondTouch.phase != TouchPhase.Moved)
        {
            return;
        }
        //3
        float newMultiTouchDistance = Vector2.Distance(firstTouch.screenPosition, secondTouch.screenPosition);
        //4
        CameraController.Instance?.Zoom(newMultiTouchDistance < lastMultiTouchDistance);
        //5
        lastMultiTouchDistance = newMultiTouchDistance;
    }

}
