using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class CatharesPlayer : MonoBehaviour
{
    public NavMeshAgent agent;
    public Camera cam;

    [SerializeField] private bool detected = false;
    [SerializeField] private float detectedTimer = 2.5f;
    [SerializeField] private bool hiding = false;
    [SerializeField] private GameObject lvl1;
    [SerializeField] private GameObject lvl2;
    [SerializeField] private GameObject lvl3;

    private Vector3 spawnPoint = new Vector3(-9, 1, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray movePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(movePosition, out var hitInfo))
            {
                agent.SetDestination(hitInfo.point);
            }
        }

        if (detected)
        {
            detectedTimer -= Time.deltaTime;
        }
        if (detectedTimer < 0)
        {
            Debug.Log("You've been arrested");
            detected = false;
            detectedTimer = 2.5f;
            transform.position = spawnPoint;
            agent.SetDestination(transform.position);
        }
        Debug.Log(transform.position);
    }

    void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Enemy")
        {
            if (!hiding)
            {
                detected = true;
                Debug.Log("BeingDetected");
            }
            
        }


        if (target.tag == "EndLvl1")
        {
            lvl2.SetActive(true);
            Debug.Log("You've finished Lvl 1");
            spawnPoint = new Vector3(-9, 1, 50);
            transform.position = spawnPoint;
            cam.transform.position = new Vector3(9.75f, 21, 50);
            agent.SetDestination(spawnPoint);
            lvl1.SetActive(false);
        }
        if (target.tag == "EndLvl2")
        {
            lvl3.SetActive(true);
            Debug.Log("You've finished Lvl 2");
            spawnPoint = new Vector3(-9, 1, 110);
            cam.transform.position = new Vector3(25, 34, 107.5f);
            transform.position = spawnPoint;
            agent.SetDestination(spawnPoint);
            lvl2.SetActive(false);
        }
        if (target.tag == "EndLvl3")
        {
            
            Debug.Log("You've escaped ! You won");
            spawnPoint = new Vector3(-50, 1, 150);
            cam.transform.position = new Vector3(-50, 20, 150);
            transform.position = spawnPoint;
            agent.SetDestination(spawnPoint);
            lvl3.SetActive(false);
        }
    }

    void OnTriggerExit(Collider target)
    {
        if (target.tag == "Enemy")
        {
            detected = false;
            detectedTimer = 2.5f;
        }
        if (target.tag == "SafeZone")
        {
            hiding = false;
        }
    }

    private void OnTriggerStay(Collider target)
    {
        if (target.tag == "SafeZone")
        {
            hiding = true;
            detected = false;
            detectedTimer = 2.5f;
        }
    }
}
