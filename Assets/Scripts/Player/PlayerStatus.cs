using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{


    private Vector3 rawInputMovement;
    private Vector3 mouseDelta;
    private Vector3 targetRotation;
    public Rigidbody rb;


    //CAMERAS
    public Camera camPlayer;
    public Camera camShadowAna;

    //Variable for GameProgression - Items
    public bool hasCastrum = false;
    public bool hasParch1 = false;
    public bool hasParch2 = false;
    public bool hasParchFrag1 = false;
    public bool hasParchFrag2 = false;
    public bool parchRestored1 = false;
    public bool parchRestored2 = false;
    public bool talkedPNJ1= false;
    public bool talkedPNJ2 = false;
    public bool hasCoin = false;
    public GameObject walls;
    public GameObject minigame;
    

    // Start is called before the first frame update
    void Start()
    {
        camPlayer.enabled = true;
        camShadowAna.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {



        ////      MOVEMENT WITH NEW INPUTMANAGER
        
        //float moveSpeed = 4;
        ////Define the speed at which the object moves.

        //float horizontalInput = Input.GetAxis("Horizontal");
        ////Get the value of the Horizontal input axis.

        //float verticalInput = Input.GetAxis("Vertical");
        ////Get the value of the Vertical input axis.

        //transform.Translate(new Vector3(horizontalInput, 0, verticalInput) * moveSpeed * Time.deltaTime);



        if (Input.GetMouseButton(0))
        {
            mouseDelta = new Vector3(0, Input.GetAxis("Mouse X"), 0); // 

            targetRotation += mouseDelta * Time.deltaTime * 100 * 3;

            rb.MoveRotation(Quaternion.Euler(targetRotation));

            /*Quaternion camTurnAngleX = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, Vector3.up);
            Quaternion camTurnAngleZ = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * RotationSpeed, Vector3.up);

            CameraOffset = camTurnAngle * CameraOffset;*/
        }


        //      MOVEMENT WITHOUT NEW INPUT MANAGER
        
        //if (Input.GetKey(KeyCode.Z))
        //{
        //    rb.AddForce(MvtSpeed * transform.forward);
        //}

        

        //if (Input.GetKey(KeyCode.Q))
        //{
        //    //targetRotation = rb.rotation.eulerAngles + new Vector3(0,-TorqueSpeed,0);
        //    targetAngle = Mathf.Lerp(targetAngle, -TorqueSpeed, 0.1f) ;

        //    //rb.rotation = Quaternion.Lerp(rb.rotation, targetRotation, accelerationCam.Evaluate(0.5f));
        //}

        //if (Input.GetKey(KeyCode.D))
        //{
        //    //targetRotation = rb.rotation.eulerAngles + new Vector3(0, TorqueSpeed, 0);
        //    targetAngle = Mathf.Lerp(targetAngle, TorqueSpeed, 0.1f);

        //}
        //if (!Input.GetKey(KeyCode.Q) && !Input.GetKey(KeyCode.D))
        //{
        //    targetAngle = Mathf.Lerp(targetAngle, 0, 0.005f);
        //}


        //    targetRotation = rb.rotation.eulerAngles + new Vector3(0, targetAngle, 0);


        //Quaternion _newRot = Quaternion.Slerp(rb.rotation, Quaternion.Euler(targetRotation), acceleration * Time.deltaTime);

        //rb.MoveRotation(_newRot);


        //if (Input.GetKey(KeyCode.S))
        //{
        //    rb.AddForce(-MvtSpeed * transform.forward);
        //}
       

        //if (Input.GetKey(KeyCode.Q))
        //{
        //    rb.AddTorque(-TorqueSpeed * transform.up);
        //}

        //if (Input.GetKey(KeyCode.D))
        //{
        //    rb.AddTorque(TorqueSpeed * transform.up);
        //}


        if (hasParchFrag1 && hasParchFrag2 && hasParch2)
        {
            parchRestored2 = true;
            hasParchFrag1 = false;
            hasParchFrag2 = false;
        }

        if (parchRestored1 && parchRestored2 && talkedPNJ1 && talkedPNJ2)
        {
            
            walls.SetActive(false);
            GameObject coinActivate = GameObject.Find("CoinActivate");
            coinActivate.SetActive(true);
        }

    }

    private void OnTriggerStay(Collider target)
    {
        if (target.tag == "ShadowAna")
        {
            if (Input.GetKeyDown(KeyCode.E) && hasParch1 && hasCastrum)
            {
                camShadowAna.enabled = !camShadowAna.enabled;
                camPlayer.enabled = !camPlayer.enabled;
                if (gameObject.activeInHierarchy)
                {
                    gameObject.SetActive(false);
                }
                else
                {
                    gameObject.SetActive(true);
                }
            }

        }
        if (target.tag == "PNJ1")
        {
            if (Input.GetKeyDown(KeyCode.E) && !talkedPNJ1)
            {
                talkedPNJ1 = true;
            }
        }
        if (target.tag == "PNJ2")
        {
            if (Input.GetKeyDown(KeyCode.E) && !talkedPNJ2)
            {
                if (talkedPNJ1 && parchRestored1 && parchRestored2)
                {
                    talkedPNJ2 = true;
                }

            }
        }
        if (target.tag == "Parchment1")
        {
            if (Input.GetKeyDown(KeyCode.E) && !hasParch1)
            {
                hasParch1 = true;
                GameObject parch1 = GameObject.Find("Parchment1");
                parch1.SetActive(false);
            }
        }
        if (target.tag == "Parchment2")
        {
            if (Input.GetKeyDown(KeyCode.E) && !hasParch2)
            {
                hasParch2 = true;
                GameObject parch2 = GameObject.Find("Parchment2");
                parch2.SetActive(false);

            }
        }
        if (target.tag == "ParchFrag1")
        {
            if (Input.GetKeyDown(KeyCode.E) && !hasParchFrag1)
            {
                hasParchFrag1 = true;
                GameObject parchFrag1 = GameObject.Find("ParchFrag1");
                parchFrag1.SetActive(false);

            }
        }
        if (target.tag == "ParchFrag2")
        {
            if (Input.GetKeyDown(KeyCode.E) && !hasParchFrag2)
            {
                hasParchFrag2 = true;
                GameObject parchFrag2 = GameObject.Find("ParchFrag2");
                parchFrag2.SetActive(false);

            }
        }
        if (target.tag == "Castrum")
        {

            if (Input.GetKeyDown(KeyCode.E) && !hasCastrum)
            {
                hasCastrum = true;
                GameObject castrum = GameObject.Find("ShadowAnaObj");
                castrum.SetActive(false);
            }
        }
        if (target.tag == "Coin")
        {

            if (Input.GetKeyDown(KeyCode.E) && !hasCoin)
            {
                hasCoin = true;
                minigame.SetActive(true);

                camPlayer.enabled = !camPlayer.enabled;
                if (gameObject.activeInHierarchy)
                {
                    gameObject.SetActive(false);
                }
                else
                {
                    gameObject.SetActive(true);
                }
            }
        }
        if (target.tag == "House")
        {
            Debug.Log("HouseCol");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("CoinMinigame");
                minigame.SetActive(true);

                camPlayer.enabled = !camPlayer.enabled;
                if (gameObject.activeInHierarchy)
                {
                    gameObject.SetActive(false);
                }
                else
                {
                    gameObject.SetActive(true);
                }
            }
        }
    }

    private void OnMovement(InputAction.CallbackContext value)
    {
        Vector2 inputMovement = value.ReadValue<Vector2>();
        rawInputMovement = new Vector3(inputMovement.x, 0, inputMovement.y);
    }
}
