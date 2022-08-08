using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private NavMeshAgent _navMeshAgent;

    private void Awake() => _navMeshAgent = GetComponent<NavMeshAgent>();
}
