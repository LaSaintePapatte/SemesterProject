using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    //private Vector3 targetRotation = Vector3.zero;
    //private float watchSpeed = 1;
    private float CameraOffset = 5f;

    public Camera mainCam;

    public Transform CoinTransform;

    public GameObject ShatteredCoin;
    public GameObject Coin;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;

    private bool LookAtCoin = false;

    private bool RotateAroundCoin = true;

    [SerializeField] 
    public float RotationSpeed = 5f;

    public float ZoomSpeed = 10f;

    public float ZoomFactor = 1f;

    private bool GoodAngle = false;
    private float GoodAngleTimer = 0.25f;

    private Vector3 targetRotation;
    private Vector3 mouseDelta;

    public Vector2 xPosAngle;
    public Vector2 yPosAngle;
    public Vector2 zPosAngle;
    public Vector2 yRotAngle1;
    public Vector2 yRotAngle2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (RotateAroundCoin && Input.GetMouseButton(0))
        {
            transform.position = CoinTransform.position;

            mouseDelta = new Vector3(-1 * Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);

            targetRotation += mouseDelta * Time.deltaTime * 100;

            transform.rotation = Quaternion.Euler(targetRotation * 3);

            /*Quaternion camTurnAngleX = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, Vector3.up);
            Quaternion camTurnAngleZ = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * RotationSpeed, Vector3.up);
            
            CameraOffset = camTurnAngle * CameraOffset;*/
        }

        
        ZoomFactor -= Input.GetAxis("Mouse ScrollWheel");
        transform.position = transform.forward * -CameraOffset * ZoomFactor;


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
                Debug.Log("2");
                if (transform.position.y < yPosAngle.y && transform.position.y > yPosAngle.x)
                {
                    Debug.Log("3");
                    if (transform.position.z < zPosAngle.y && transform.position.y > zPosAngle.x)
                    {
                        Debug.Log("4");
                        if (transform.rotation.y > yRotAngle1.x && transform.rotation.y < yRotAngle1.y)
                        {
                            GoodAngle = true;
                            Debug.Log("5");
                        }
                        else if (transform.rotation.y > yRotAngle2.x && transform.rotation.y < yRotAngle2.y)
                        {
                            GoodAngle = true;
                            Debug.Log("6");
                        }
                        else
                        {
                            GoodAngle = false;
                            GoodAngleTimer = 0.25f;
                        }
                    }
                }
            }
        

        //Debug.Log(transform.rotation.y);
        //Debug.Log(ZoomFactor);
        if (GoodAngle)
        {
            GoodAngleTimer -= Time.deltaTime;
        }

        if (GoodAngleTimer <= 0)
        {
            Debug.Log("YouWon");
            
            GoodAngle = false;
            GoodAngleTimer = 0.25f;
            Coin.SetActive(true);
            ShatteredCoin.SetActive(false);
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