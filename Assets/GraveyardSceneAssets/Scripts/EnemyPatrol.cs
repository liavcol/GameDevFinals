using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField]
    private Transform[] waypoints;
    [SerializeField]
    private float waitTime = 3;
    [SerializeField]
    private float speed = 5;

    private int currWaypoint = 0;
    private bool isWaiting = false;

    private Rigidbody _rigidbody;


    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[currWaypoint].position) < 1)
        {
            currWaypoint++;
            currWaypoint %= waypoints.Length;
            StartCoroutine(WaitAtWaypoint());
        }
    }

    private void FixedUpdate()
    {
        if (!isWaiting)
            _rigidbody.velocity = (waypoints[currWaypoint].position - _rigidbody.position).normalized * speed;        
    }

    private IEnumerator WaitAtWaypoint()
    {
        isWaiting = true;
        _rigidbody.velocity = Vector3.zero;
        yield return new WaitForSeconds(waitTime);
        transform.LookAt(waypoints[currWaypoint]);
        isWaiting = false;
    }
}
