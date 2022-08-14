using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2D : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    Vector2 rawInput;
    // ViewPort (the player can't come out of the camera)
    Vector2 minLimit;
    Vector2 maxLimit;

    Shooter2D shooter;

    void Awake()
    {
        shooter = GetComponent<Shooter2D>();
    }

    void Start()
    {
        InitLimits();
    }
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 delta = rawInput * moveSpeed * Time.deltaTime;
        // Movement of the player
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minLimit.x, maxLimit.x);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minLimit.y, maxLimit.y);
        transform.position = newPos;
    }
    // ViewPort
    void InitLimits()
    {
        Camera mainCamera = Camera.main; //The game camera
        minLimit = mainCamera.ViewportToWorldPoint(new Vector2(0, 0)); //Bottom left
        maxLimit = mainCamera.ViewportToWorldPoint(new Vector2(1, 1)); //Top right

    }
    // Move action- I chose "send messages" behavior (move action type: vector 2)
    // Calld when we press a key down or lift off
    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>(); 
    }

    void OnFire(InputValue value)
    {
        if(shooter!= null)
        {
            shooter.isFiring = value.isPressed;
        }
    }
}
