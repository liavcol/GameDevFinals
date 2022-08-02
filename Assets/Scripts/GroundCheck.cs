using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private float gravityMultiplier = 1;
    [SerializeField] private float checkDistance = 0.2f;
    [SerializeField] private LayerMask groundLayer;
    private CharacterController parentCharacterController;

    private Vector3 gravityAccel;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        parentCharacterController = transform.parent.GetComponent<CharacterController>();        
    }

    private void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(transform.position, checkDistance, groundLayer);

        if (isGrounded && gravityAccel.y < 0)
            gravityAccel.y = -2;
        else
            gravityAccel.y += -9.81f * gravityMultiplier * Time.fixedDeltaTime;
        parentCharacterController.Move(gravityAccel * Time.fixedDeltaTime);
    }
}
