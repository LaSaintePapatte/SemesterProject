using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class CameraManagerHouse : MonoBehaviour
{
    //private Vector3 targetRotation = Vector3.zero;
    //private float watchSpeed = 1;
    private float cameraOffset = 5f;

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

    public float zoomSpeed = 10f;

    public float zoomFactor = 1f;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (rotateAroundCoin && Touch.activeTouches.Count >= 1)
        {
            Debug.Log("Oui");

            transform.position = modelTransform.position;

            mouseDelta = new Vector3(-1 * Touch.activeTouches[0].delta.normalized.y, Touch.activeTouches[0].delta.normalized.x, 0);

            targetRotation += mouseDelta * Time.deltaTime * 100 * 3;

            transform.rotation = Quaternion.Euler(targetRotation);
        }

        if (rotateAroundCoin && Input.GetMouseButton(0))
        {
            transform.position = modelTransform.position;

            mouseDelta = new Vector3(-1 * Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);

            targetRotation += mouseDelta * Time.deltaTime * 100;

            transform.rotation = Quaternion.Euler(targetRotation * 3);

            /*Quaternion camTurnAngleX = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, Vector3.up);
            Quaternion camTurnAngleZ = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * RotationSpeed, Vector3.up);
            
            CameraOffset = camTurnAngle * CameraOffset;*/
        }

        
        zoomFactor -= Input.GetAxis("Mouse ScrollWheel");
        transform.position = transform.forward * -cameraOffset * zoomFactor;


        /*
        Vector3 NewPos = CoinTransform.position + CameraOffset * ZoomFactor;

        transform.position = Vector3.Slerp(transform.position, NewPos, SmoothFactor);

        if (LookAtCoin || RotateAroundCoin)
        {
            transform.LookAt(CoinTransform);
        }
        */

        

        
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
        

        //Debug.Log(transform.rotation.y);
        //Debug.Log(ZoomFactor);
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
            SceneManager.LoadScene("S_Castrum");
        }
        
        /*
        if (Input.GetMouseButton(0))
        {
            transform.position = Coin.transform.position;
            camRotation += Input.GetAxis("Mouse X");
            transform.rotation = Quaternion.Euler(0, camRotation, 0);
            transform.position -= transform.forward * -1 * 10;
        }

        Vector3 mouseDelta = new Vector3(-1 * Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
        

        //Debug.Log(rStick);

        targetRotation += mouseDelta * Time.deltaTime * 3 * watchSpeed;

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetRotation), 1.5f * Time.deltaTime);*/
    }
}
