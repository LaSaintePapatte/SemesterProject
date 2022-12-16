using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class CameraManagerCoin : MonoBehaviour
{
    //private Vector3 targetRotation = Vector3.zero;
    //private float watchSpeed = 1;

    private PlayerControls playerControls;
    public float cameraOffset = 5f;

    public Camera mainCam;

    public Transform modelTransform;

    public GameObject shatteredModel;
    public GameObject model;

    [Range(0.01f, 1.0f)]
    public float smoothFactor = 0.5f;

    //private bool lookAtCoin = false;

    private bool rotateAroundCoin = true;

    [SerializeField] 
    public float rRotationSpeed = 5f;

    //public float zoomSpeed = 10f;

    //public float zoomFactor = 1f;

    private bool goodAngle = false;
    private float goodAngleTimer = 0.5f;

    private Vector3 targetRotation;
    private Vector3 mouseDelta;

    public Vector2 xPosAngle;
    public Vector2 yPosAngle;
    public Vector2 zPosAngle;
    public Vector2 yRotAngle1;
    public Vector2 yRotAngle2;

    private bool end = false;
    private float endTimer = 0;


    private void Awake()
    {

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
        Debug.Log(cameraOffset);


        if (Touch.activeTouches.Count == 1)
        {
            transform.position = modelTransform.position;

            //mouseDelta = new Vector3(-1 * Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);

            //targetRotation += mouseDelta * Time.deltaTime * 100;

            //transform.rotation = Quaternion.Euler(targetRotation * 3);

            Vector3 curTouchDelta = new Vector3(-1 * Touch.activeTouches[0].delta.normalized.y, Touch.activeTouches[0].delta.normalized.x, 0);

            targetRotation += curTouchDelta * Time.deltaTime * 100/3;

            transform.rotation = Quaternion.Euler(targetRotation);
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetRotation), 1f);
        }

        cameraOffset = Mathf.Clamp(cameraOffset, 1f, 10f);
        //zoomFactor -= Input.GetAxis("Mouse ScrollWheel");
        transform.position = transform.forward * -cameraOffset;




        

           if (transform.position.x < xPosAngle.y && transform.position.x > xPosAngle.x)
            {
                //Debug.Log("2");
                if (transform.position.y < yPosAngle.y && transform.position.y > yPosAngle.x)
                {
                    //Debug.Log("3");
                    if (transform.position.z < zPosAngle.y && transform.position.z > zPosAngle.x)
                    {
                        Debug.Log("4");
                        if (transform.rotation.y < yRotAngle1.y && transform.rotation.y > yRotAngle1.x)
                        {
                            goodAngle = true;
                            Debug.Log("5");
                        }
                        else if (transform.rotation.y < yRotAngle2.y && transform.rotation.y > yRotAngle2.x)
                        {
                            goodAngle = true;
                            Debug.Log("6");
                        }
                        else
                        {
                            goodAngle = false;
                            goodAngleTimer = 0.5f;
                        }
                    }
                }
            }
        

        if (goodAngle)
        {
            goodAngleTimer -= Time.deltaTime;
        }
        
        if (goodAngleTimer <= 0)
        {
            Debug.Log("YouWon");

            goodAngle = false;
            goodAngleTimer = 0.5f;
            model.SetActive(true);
            shatteredModel.SetActive(false);
            end = true;
        }

        if (end)
        {
            endTimer += Time.deltaTime;
        }

        if (endTimer > 2.5f)
        {
            SceneManager.LoadScene("S_Exfiltration");
        }
        
    }
}
