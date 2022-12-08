using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private float sensitivityHor = 9.0f;
    [SerializeField] private float sensitivityVert = 9.0f;
    [SerializeField] private float minimumVert = -45.0f;
    [SerializeField] private float maximumVert = 45.0f;
    private float _rotationX = 0;
    private Rigidbody PlayerRigidbody;

    void Start()
    {
        PlayerRigidbody = GetComponent<Rigidbody>();
        if (PlayerRigidbody != null)
        {
            PlayerRigidbody.freezeRotation = true;
        }
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            _rotationX -= Input.GetTouch(0).deltaPosition.y * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
            float delta = Input.GetTouch(0).deltaPosition.x * sensitivityHor;
            float rotationY = transform.localEulerAngles.y + delta;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
    }
}