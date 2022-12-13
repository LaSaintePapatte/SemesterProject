using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class TouchController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PlayerControls playerControls;

    private Vector2 curTouch;
    private Vector3 targetRotation;

    private bool isOrbital = false;
    [SerializeField] private bool isCharaRota = true;


    public float touchSpeed = 10f;

    private float lastMultiTouchDistance;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

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

        

        curTouch = playerControls.Player.Look.ReadValue<Vector2>();


        if (Touch.activeFingers.Count == 1)
        {

            Debug.Log("1");
            CharaRota(Touch.activeTouches[0]);
        }
        else if (Touch.activeFingers.Count == 2)
        {
            Debug.Log("2");
            ZoomCamera(Touch.activeTouches[0], Touch.activeTouches[1]);
        }
    }

    

private void OnInput(Touch touch)
    {
        //if (isOrbital)
        //{
        //    if (Touch.activeFingers.Count == 1)
        //    {
        //        MoveOrbital(touch);
        //    }
        //    else if (Touch.activeFingers.Count == 2)
        //    {
        //        ZoomCamera(Touch.activeTouches[0], Touch.activeTouches[1]);
        //    }
        //}
        if (isCharaRota)
        {
            CharaRota(touch);
        }
    }

    //if (rotateAroundCoin && Input.GetMouseButton(0))
    //    {
    //        transform.position = modelTransform.position;

    //        mouseDelta = new Vector3(-1 * Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);

    //        targetRotation += mouseDelta* Time.deltaTime * 100;

    //        transform.rotation = Quaternion.Euler(targetRotation* 3);

            
    //}

private void MoveOrbital (Touch touch)
    {
        //transform.position = modelTransform.position;

        Vector3 curTouchDelta = new Vector3(-1 * touch.delta.normalized.y, touch.delta.normalized.x, 0);

        targetRotation += curTouchDelta * Time.deltaTime * 100;
        
        transform.rotation = Quaternion.Euler(targetRotation);
    }


    private void CharaRota(Touch touch)
    {
        Vector3 curTouchDelta = new Vector3(0, touch.delta.normalized.x, 0);

        targetRotation += curTouchDelta * Time.deltaTime * 100 * 3;

        rb.MoveRotation(Quaternion.Euler(targetRotation));
    }

    private void ZoomCamera(Touch firstTouch, Touch secondTouch)
    {
        //1
        if (firstTouch.phase == TouchPhase.Began || secondTouch.phase == TouchPhase.Began)
        {
            lastMultiTouchDistance = Vector2.Distance(firstTouch.screenPosition, secondTouch.screenPosition);
        }
        //2
        if (firstTouch.phase != TouchPhase.Moved || secondTouch.phase != TouchPhase.Moved)
        {
            return;
        }
        //3
        float newMultiTouchDistance = Vector2.Distance(firstTouch.screenPosition, secondTouch.screenPosition);
        //4
        CameraController.Instance?.Zoom(newMultiTouchDistance < lastMultiTouchDistance);
        //5
        lastMultiTouchDistance = newMultiTouchDistance;
    }

}
