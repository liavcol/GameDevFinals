using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float runningMultiplier = 2;
    [SerializeField] private float runningTransitionRate = 1;

    private float runAccel;

    private CharacterController _characterController;

    private void Awake() => _characterController = GetComponent<CharacterController>();
    

    private void Update()
    {
        Vector3 moveX = transform.right * Input.GetAxis("Horizontal");
        Vector3 moveZ = transform.forward * Input.GetAxis("Vertical");
        Vector3 movement = speed * Time.deltaTime * (moveX + moveZ);

        if (Input.GetKey(KeyCode.LeftShift))
            runAccel = Mathf.Min(runAccel + runningTransitionRate * Time.deltaTime, runningMultiplier);
        else
            runAccel = 1;

        _characterController.Move(movement*runAccel);
    }
}
