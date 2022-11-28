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

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;

    public bool LookAtCoin = false;

    public bool RotateAroundCoin = true;

    public float RotationSpeed = 5f;

    public float ZoomSpeed = 10f;

    public float ZoomFactor = 1f;

    private bool GoodAngle = false;
    private float GoodAngleTimer = 0.25f;

    private Vector3 targetRotation;
    private Vector3 mouseDelta;

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

        Debug.Log(transform.rotation.y);


        if (transform.position.x < -5.11 && transform.position.x > -5.22)
        {
            if(transform.position.y < 6.87 && transform.position.y > 6.72)
            {
                if (transform.position.z < 4.13 && transform.position.y > 4.20)
                {
                    if (transform.rotation.y > -0.835 && transform.rotation.y < -0.827)
                    {
                        GoodAngle = true;
                    }
                    else if (transform.rotation.y > 0.827 && transform.rotation.y < 0.835)
                    {
                        GoodAngle = true;
                    }
                    else
                    {
                        GoodAngle = false;
                        GoodAngleTimer = 0.25f;
                    }
                }
            }
        }
        
        if (GoodAngle)
        {
            GoodAngleTimer -= Time.deltaTime;
        }

        if (GoodAngleTimer <= 0)
        {
            Debug.Log("YouWon");
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
