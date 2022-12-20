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
        //camShadowAna.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {


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
            if (/*Input.GetKey(KeyCode.E) &&*/ hasParch1 && hasCastrum)
            {
                //camShadowAna.enabled = !camShadowAna.enabled;
                camPlayer.enabled = !camPlayer.enabled;
                camShadowAna.enabled = !camShadowAna.enabled;
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
            if (  !talkedPNJ1)
            {
                talkedPNJ1 = true;
            }
        }
        if (target.tag == "PNJ2")
        {
            if (  !talkedPNJ2)
            {
                if (talkedPNJ1 && parchRestored1 && parchRestored2)
                {
                    talkedPNJ2 = true;
                }

            }
        }
        if (target.tag == "Parchment1")
        {
            if (  !hasParch1)
            {
                hasParch1 = true;
                GameObject parch1 = GameObject.Find("Parchment1");
                parch1.SetActive(false);
            }
        }
        if (target.tag == "Parchment2")
        {
            if (  !hasParch2)
            {
                hasParch2 = true;
                GameObject parch2 = GameObject.Find("Parchment2");
                parch2.SetActive(false);

            }
        }
        if (target.tag == "ParchFrag1")
        {
            if (  !hasParchFrag1)
            {
                hasParchFrag1 = true;
                GameObject parchFrag1 = GameObject.Find("ParchFrag1");
                parchFrag1.SetActive(false);

            }
        }
        if (target.tag == "ParchFrag2")
        {
            if (  !hasParchFrag2)
            {
                hasParchFrag2 = true;
                GameObject parchFrag2 = GameObject.Find("ParchFrag2");
                parchFrag2.SetActive(false);

            }
        }
        if (target.tag == "Castrum")
        {

            if (  !hasCastrum)
            {
                hasCastrum = true;
                GameObject castrum = GameObject.Find("ShadowAnaObj");
                castrum.SetActive(false);
            }
        }
        if (target.tag == "Coin")
        {

            if (!hasCoin)
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
            if (true)
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

    //private void OnMovement(InputAction.CallbackContext value)
    //{
    //    Vector2 inputMovement = value.ReadValue<Vector2>();
    //    rawInputMovement = new Vector3(inputMovement.x, 0, inputMovement.y);
    //}
}
