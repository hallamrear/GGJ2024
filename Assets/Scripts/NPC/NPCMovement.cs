using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MovementBase
{
    [Header("NPC Specific Movement")]
    public float directionTime = 100;
    public List<MoveBehaviour> movementOptions;

    private bool IsStopped = false;

    // Start is called before the first frame update
    void Start()
    {
        foreach (MoveBehaviour b in movementOptions)
        {
            if (b.Active)
            {
                b.InitialiseMovement(rigidBody.position);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(!IsStopped)
        {
            GetHeadingDriection();
            moveDirection += headingDirection;
            moveDirection.Normalize();
            Move();
        }
    }

    /// <summary>
    /// Calculate Heading direction based on the active movebehaviour
    /// </summary>
    private void GetHeadingDriection()
    {
        foreach(MoveBehaviour b in movementOptions)
        {
            if(b.Active)
            {
                headingDirection = b.CalculateMoveDirection(rigidBody.position);
            }
        }
    }

    /// <summary>
    /// Move in the direction of the heading, uses rigid body 2d
    /// </summary>
    private void Move()
    {
        rigidBody.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    /// <summary>
    /// Toggles movement on/off
    /// </summary>
    public void ToggleMovement()
    {
        //Debug.Log("stop moving");
        IsStopped = !IsStopped;
        rigidBody.velocity = Vector2.zero;
    }
}
