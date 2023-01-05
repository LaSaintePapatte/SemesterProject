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
    [SerializeField] private Camera camPlayer;
    [SerializeField] private Camera camShadowAna;

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

    public bool talkingPNJ1 = false;
    public bool talkingPNJ2 = false;


    [SerializeField] private GameObject walls;
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
}
