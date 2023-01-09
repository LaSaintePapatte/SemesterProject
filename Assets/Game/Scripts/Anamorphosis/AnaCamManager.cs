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
using UnityEngine.UI;

public class AnaCamManager : MonoBehaviour
{

    //[SerializeField] private Image fadeImage;
    //[SerializeField] private Animator fadeOutAnim;

    private PlayerControls playerControls;
    public float cameraOffset = 5f;

    [SerializeField] private Camera mainCam;

    [SerializeField] private Transform modelTransform;

    [SerializeField] private GameObject shatteredModel;
    [SerializeField] private GameObject model;

    [SerializeField] private LevelManager lvlManager;

    private bool goodAngle = false;
    private float goodAngleTimer = 0.5f;

    private Vector3 targetRotation;
    private Vector3 mouseDelta;

    private Vector2 startPos;

    private float zoomFactor = 1;

    [SerializeField] private Vector2 xPosAngle;
    [SerializeField] private Vector2 yPosAngle;
    [SerializeField] private Vector2 zPosAngle;

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
        if (Touch.activeTouches.Count == 1)
        {
            transform.position = modelTransform.position;

            if (Touch.activeTouches[0].phase == TouchPhase.Began)
            {
                startPos = Touch.activeTouches[0].startScreenPosition;
            }
            else if (Touch.activeTouches[0].phase == TouchPhase.Stationary)
            {
                startPos = Touch.activeTouches[0].screenPosition;
            }

            else if (Touch.activeTouches[0].phase == TouchPhase.Moved)
            {
                Vector3 curTouchDelta = new Vector3(-1 * (Touch.activeTouches[0].screenPosition.y - startPos.y), Touch.activeTouches[0].screenPosition.x - startPos.x, 0);
                

                targetRotation += curTouchDelta * Time.deltaTime * 3;

                transform.rotation = Quaternion.Euler(targetRotation);
            }    
        }

        cameraOffset = Mathf.Clamp(cameraOffset, 1f, 10f);
        zoomFactor -= Input.GetAxis("Mouse ScrollWheel");
        transform.position = transform.forward * -cameraOffset * zoomFactor;

        Debug.Log(transform.position);

           if (transform.position.x < xPosAngle.y && transform.position.x > xPosAngle.x)
           {
                if (transform.position.y < yPosAngle.y && transform.position.y > yPosAngle.x)
                {
                    if (transform.position.z < zPosAngle.y && transform.position.z > zPosAngle.x)
                    {
                    goodAngle = true;
                    }
                else
                    {
                        goodAngle = false;
                        goodAngleTimer = 0.5f;
                    }
                }
           }
        

        if (goodAngle)
        {
            goodAngleTimer -= Time.deltaTime;
        }
        
        if (goodAngleTimer <= 0)
        {
            //Debug.Log("YouWon");

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
            lvlManager.LoadNextLevel();
        }  
    }
}