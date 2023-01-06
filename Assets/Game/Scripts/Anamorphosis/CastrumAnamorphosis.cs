using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class CastrumAnamorphosis : MonoBehaviour
{

    private Vector3 mouseDelta;

    private Vector3 targetRotation;

    private bool goodAngle = false;
    private float goodAngleTimer = 0.5f;

    [SerializeField] private Camera camShadowAna;
    [SerializeField] private Camera camPlayer;
    [SerializeField] private GameObject camPlayerObj;
    [SerializeField] private GameObject camShadowAnaObj;
    [SerializeField] private GameObject player;


    [SerializeField] private Vector2 xRotAngle;
    [SerializeField] private Vector2 yRotAngle;

    [SerializeField] private GameObject anamorphisisHouses;
    [SerializeField] private GameObject houses;
    PlayerStatus playerScript;

    // Start is called before the first frame update
    void Start()
    {
        targetRotation = transform.rotation.eulerAngles;
        playerScript = player.GetComponent<PlayerStatus>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Touch.activeTouches.Count >= 1)
        {
            Debug.Log("Oui");

            mouseDelta = new Vector3(-1 * Touch.activeTouches[0].delta.normalized.y, Touch.activeTouches[0].delta.normalized.x, 0);

            targetRotation += mouseDelta * Time.deltaTime * 3;

            transform.rotation = Quaternion.Euler(targetRotation);
        }

        if (Input.GetMouseButton(0))
        {

            mouseDelta = new Vector3(-1 * Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);

            targetRotation += mouseDelta * Time.deltaTime * 100 * 3;

            transform.rotation = Quaternion.Euler(targetRotation);

            /*Quaternion camTurnAngleX = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, Vector3.up);
            Quaternion camTurnAngleZ = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * RotationSpeed, Vector3.up);
            
            CameraOffset = camTurnAngle * CameraOffset;*/
        }

        
        //Debug.Log(transform.rotation.x);
        //Debug.Log(transform.rotation.y);

        if (Mathf.Abs(transform.rotation.x) < xRotAngle.y && Mathf.Abs(transform.rotation.x) > xRotAngle.x)
        {
            Debug.Log("2");
            if (Mathf.Abs(transform.rotation.y) < yRotAngle.y && Mathf.Abs(transform.rotation.y) > yRotAngle.x)
            {
                Debug.Log("3");
                goodAngle = true;
            }
            else
            {
                goodAngle = false;
                goodAngleTimer = 0.5f;
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
            goodAngleTimer = 0.55f;
            houses.SetActive(true);
            anamorphisisHouses.SetActive(false);

            //camShadowAna.enabled = !camShadowAna.enabled;
            //camPlayer.enabled = !camPlayer.enabled;
            camShadowAnaObj.SetActive(false);
            camPlayerObj.SetActive(true);

            //if (player.activeInHierarchy)
            //{
            //    player.SetActive(false);
            //}
            //else
            //{
            //    player.SetActive(true);
            //}

            playerScript.parchRestored1 = true;
        }
    }
}
