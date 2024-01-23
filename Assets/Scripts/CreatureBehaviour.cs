using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.UI.Image;

public class CreatureBehaviour : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    private Vector3 currentWaypoint;

    public float minRadius = 5f;

    public float maxRadius = 10f;

    public float totalFOV = 90f;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f) {
            currentWaypoint = GetRandomPositionInPieSlice();
            navMeshAgent.SetDestination(currentWaypoint);
        }
    }

    protected Vector3 GetRandomPositionInPieSlice()
    {
        Quaternion rotation = Quaternion.AngleAxis(Random.Range(-totalFOV / 2, totalFOV / 2), transform.up);

        Vector3 direction = rotation * transform.forward;

        float distance = Random.Range(minRadius, maxRadius);

        return transform.position + direction * distance;
    }
}
