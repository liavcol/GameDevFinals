using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerBehaviour : MonoBehaviour
{
    [SerializeField] private Transform runFrom;
    [SerializeField] private float speed;
    [SerializeField] private float safeDistance;

    private CharacterController characterController;
    private Animator animator;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        Vector3 fleeDir = transform.position - runFrom.position;
        fleeDir.y = 0;
        if (fleeDir.magnitude < safeDistance)
        {
            characterController.Move(speed * Time.deltaTime * fleeDir.normalized);

            Quaternion lookDir = Quaternion.LookRotation(fleeDir, transform.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookDir, speed * Time.deltaTime);
        }

        animator.SetFloat("Speed", characterController.velocity.magnitude);
    }
}
