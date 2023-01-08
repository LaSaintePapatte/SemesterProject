using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class CastrumAnamorphosis : MonoBehaviour
{

    private Vector3 touchDelta;
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
    [SerializeField] private CanvasGroup shadowAnaUI;
    [SerializeField] private CanvasGroup playerUI;

    private PlayerStatus playerScript;
    private InteractScript interactScript;
    // Start is called before the first frame update
    void Start()
    {
        targetRotation = transform.rotation.eulerAngles;
        playerScript = player.GetComponent<PlayerStatus>();
        interactScript = player.GetComponent<InteractScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Touch.activeTouches.Count >= 1)
        {
            //Debug.Log("Oui");

            touchDelta = new Vector3( Touch.activeTouches[0].delta.normalized.y, Touch.activeTouches[0].delta.normalized.x, 0);

            targetRotation += touchDelta * Time.deltaTime * 10 * 3;

            transform.rotation = Quaternion.Euler(targetRotation);
        }

        if (Input.GetMouseButton(0))
        {
            mouseDelta = new Vector3( Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);

            targetRotation += mouseDelta * Time.deltaTime * 10 * 3;

            transform.rotation = Quaternion.Euler(targetRotation);
        }

        
        

        if (Mathf.Abs(transform.rotation.x) < xRotAngle.y && Mathf.Abs(transform.rotation.x) > xRotAngle.x)
        {
            Debug.Log("2");
            if (transform.rotation.y < yRotAngle.y && transform.rotation.y > yRotAngle.x)
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
            Debug.Log(transform.rotation);
            Debug.Log("YouWon");
            playerScript.parchRestored1 = true;
            goodAngle = false;
            goodAngleTimer = 0.5f;

            houses.SetActive(true);

            interactScript.inInteraction = false;
            shadowAnaUI.interactable = false;
            shadowAnaUI.blocksRaycasts = false;
            shadowAnaUI.alpha = 0f;
            playerUI.interactable = true;
            playerUI.blocksRaycasts = true;
            playerUI.alpha = 1f;

            camShadowAnaObj.SetActive(false);
            camPlayerObj.SetActive(true);

            anamorphisisHouses.SetActive(false);
        }
    }
}
