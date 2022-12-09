//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.InputSystem.EnhancedTouch;
//using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
//using TouchPhase = UnityEngine.InputSystem.TouchPhase;

//public class InputManager : MonoBehaviour
//{
//    public float touchSpeed = 10f;

//    private float lastMultiTouchDistance;

//    private void Awake()
//    {
//        EnhancedTouchSupport.Enable();
//    }

//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {

//        if (Touch.activeFingers.Count == 1)
//        {
//            MoveCamera(Touch.activeTouches[0]);
//        }
//        else if (Touch.activeFingers.Count == 2)
//        {
//            ZoomCamera(Touch.activeTouches[0],
//              Touch.activeTouches[1]);
//        }
//    }

//    private void MoveCamera(Touch touch)
//    {
//        //1
//        if (touch.phase != TouchPhase.Moved)
//        {
//            return;
//        }
//        //2
//        //
//        Vector3 newPosition = new Vector3(-touch.delta.normalized.x, 0, -touch.delta.normalized.y) * Time.deltaTime * touchSpeed;
//        //3
//        CameraController.Instance?.Move(newPosition);
//    }

//    private void ZoomCamera(Touch firstTouch, Touch secondTouch)
//    {
//        //1
//        if (firstTouch.phase == TouchPhase.Began || secondTouch.phase == TouchPhase.Began)
//        {
//            lastMultiTouchDistance = Vector2.Distance(firstTouch.screenPosition, secondTouch.screenPosition);
//        }
//        //2
//        if (firstTouch.phase != TouchPhase.Moved || secondTouch.phase != TouchPhase.Moved)
//        {
//            return;
//        }
//        //3
//        float newMultiTouchDistance = Vector2.Distance(firstTouch.screenPosition, secondTouch.screenPosition);
//        //4
//        CameraController.Instance?.Zoom(newMultiTouchDistance < lastMultiTouchDistance);
//        //5
//        lastMultiTouchDistance = newMultiTouchDistance;
//    }

//}
