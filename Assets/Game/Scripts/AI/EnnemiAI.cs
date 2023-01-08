using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemiAI : MonoBehaviour
{

    NavMeshAgent agent;

    public Transform[] waypoints;

    int waypointIndex = 0;

    [SerializeField] private float stopTimer = 2.5f;

    Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target) < 1)
        {
            stopTimer -= Time.deltaTime;
        }
        if (stopTimer < 0)
        {
            IterateWaypointIndex();
            UpdateDestination();
            stopTimer = 2.5f;
        }
    }

    void UpdateDestination()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
    }

    void IterateWaypointIndex()
    {
        waypointIndex++;
        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }
}
