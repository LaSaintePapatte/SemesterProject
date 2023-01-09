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

    public GameObject camShadowAna;
    public GameObject camPlayer;
    public GameObject player;

    [SerializeField] private CanvasGroup playerUI;
    [SerializeField] private CanvasGroup minigameUI;


    [SerializeField] private Vector2 xRotAngle;
    [SerializeField] private Vector2 yRotAngle;

    public GameObject anamorphisisHouses;
    public GameObject houses;
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

            targetRotation += mouseDelta * Time.deltaTime * 10 * 3;

            transform.rotation = Quaternion.Euler(targetRotation);
        }

        if (Input.GetMouseButton(0))
        {

            mouseDelta = new Vector3(-1 * Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);

            targetRotation += mouseDelta * Time.deltaTime * 10 * 3;

            transform.rotation = Quaternion.Euler(targetRotation);
        }
        
        Debug.Log(transform.rotation.x);
        Debug.Log(transform.rotation.y);

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


            camShadowAna.SetActive(false);
            camPlayer.SetActive(true);


            playerUI.interactable = true;
            playerUI.blocksRaycasts = true;
            playerUI.alpha = 1f;
            minigameUI.interactable = false;
            minigameUI.blocksRaycasts = false;
            minigameUI.alpha = 0f;
            FindObjectOfType<InteractScript>().inInteraction = false;

            playerScript.parchRestored1 = true;

            houses.SetActive(true);
            anamorphisisHouses.SetActive(false);
        }
    }
}
