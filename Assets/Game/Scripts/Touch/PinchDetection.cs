using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchDetection : MonoBehaviour
{

    [SerializeField] private AnaCamManager coinGameScript;
    private PlayerControls controls;
    private Coroutine zoomCoroutine;
    //[SerializeField] private Transform cameraTransform;
    //[SerializeField] private Camera cam;
    private void Awake()
    {
        controls = new PlayerControls();

    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        controls.TouchMinigame.SecondaryTouchContact.started += _ => ZoomStart();
        controls.TouchMinigame.SecondaryTouchContact.canceled += _ => ZoomEnd();
    }

    private void ZoomStart()
    {
        zoomCoroutine = StartCoroutine(ZoomDetection());
    }

    private void ZoomEnd()
    {
        StopCoroutine(zoomCoroutine);
    }

    IEnumerator ZoomDetection()
    {
        float previousDistance = 0f, distance = 0f;

        while (true)
        {
            distance = Vector2.Distance(controls.TouchMinigame.PrimaryFingerPos.ReadValue<Vector2>(), controls.TouchMinigame.SecondaryFingerPos.ReadValue<Vector2>());
            
            //DETECTION
            //Zoom out
            if (distance > previousDistance)
            {
                //Vector3 targetPosition = cameraTransform.position;
                //targetPosition = targetPosition - cameraTransform.forward;
                //cameraTransform.position = Vector3.Slerp(cameraTransform.position, targetPosition, Time.deltaTime * zoomSpeed);

                //float targetFOV = cam.fieldOfView;
                //targetFOV -= 1f;
                //cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, targetFOV, Time.deltaTime * zoomSpeed);

                coinGameScript.cameraOffset -= .1f;

                
            }
            //Zoom in
            if (distance < previousDistance)
            {
                

                coinGameScript.cameraOffset += .1f;
                
                
            }

            //Better accuracy : 
            // if (Vector.Dot(primaryDelta, secondaryDelta) < -.9f)

            //Keeping track of previous distance for next loop
            previousDistance = distance;

            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
