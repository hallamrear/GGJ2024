using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MovementBase
{
    [Header("NPC Specific Movement")]
    public float directionTime = 100;

    private float currentTime = 0;
    private bool IsStopped = false;

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
        if(!IsStopped)
        {
            rigidBody.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        }
    }

    public void ToggleMovement()
    {
        //Debug.Log("stop moving");
        IsStopped = !IsStopped;
        rigidBody.velocity = Vector2.zero;
    }
}
