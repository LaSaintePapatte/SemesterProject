using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Vector3 targetRotation = Vector3.zero;
    private float watchSpeed = 1;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseDelta = new Vector3(-1 * Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
        

        //Debug.Log(rStick);

        targetRotation += mouseDelta * Time.deltaTime * 3 * watchSpeed;

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetRotation), 1.5f * Time.deltaTime);
    }
}
