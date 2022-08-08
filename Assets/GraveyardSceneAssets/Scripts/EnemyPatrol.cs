using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float waitTime = 3;
    [SerializeField] private float speed = 5;

    private int currWaypoint = 0;
    private bool isWaiting = false;

    //private Rigidbody _rigidbody;
    private NavMeshAgent _navMeshAgent;

    private void Awake() => _navMeshAgent = GetComponent<NavMeshAgent>();

    private void Start()
    {
        _navMeshAgent.speed = speed;
        _navMeshAgent.SetDestination(waypoints[currWaypoint].position);
    }

    private void Update()
    {
        if (isWaiting)
            return;

        if (Vector3.Distance(transform.position, waypoints[currWaypoint].position) < 1)
        {
            currWaypoint++;
            currWaypoint %= waypoints.Length;
            _navMeshAgent.SetDestination(waypoints[currWaypoint].position);
            StartCoroutine(WaitAtWaypoint());
        }
    }

    private IEnumerator WaitAtWaypoint()
    {
        isWaiting = true;
        _navMeshAgent.isStopped = true;
        yield return new WaitForSeconds(waitTime);
        isWaiting = false;
        _navMeshAgent.isStopped = false;
    }
}