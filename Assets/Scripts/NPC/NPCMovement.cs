using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    [Header ("Physics")]
    public Rigidbody2D rigidBody;

    [Header ("Move stats")]
    public float moveSpeed = 5;
    public Vector2 headingDirection = new Vector2(0, 1); 
    public float directionTime = 100;

    private Vector2 moveDirection = new Vector2(0, 0);
    private float currentTime = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        currentTime++;
        if(currentTime == directionTime)
        {
            headingDirection = Vector2.zero - headingDirection;
            currentTime = 0;
        }
        moveDirection += headingDirection;
        moveDirection.Normalize();
        Move();
    }

    private void Move()
    {
        rigidBody.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
