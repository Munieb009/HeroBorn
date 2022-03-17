using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // Unity Navigation classes

public class EnemyBehavior : MonoBehaviour
{
    public Transform patrolroute;
    // hold all the child transform component in List
    public List<Transform> locations;
    private int locationindex = 0;

    private NavMeshAgent nav;
    private void Start()
    {
        InitializePatrolRoute();
        nav = GetComponent<NavMeshAgent>();
        MovetoNextPoint();
    }

    void MovetoNextPoint()
    {
        if (locations.Count == 0)
            return;
        nav.destination = locations[locationindex].position;
        locationindex = (locationindex + 1) % locations.Count;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            Debug.Log("Player Detected -- attack");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.name == "Player")
        {
            Debug.Log("Player is out of range, resume Patrol");
        }
    }
    // fill the location with transform value
    void InitializePatrolRoute()
    {
        foreach(Transform child in patrolroute)
        {
            locations.Add(child);
        }
    }

    private void Update()
    {
        if(nav.remainingDistance < 0.2f && !nav.pathPending)
        {
            MovetoNextPoint();
        }
    }
}
