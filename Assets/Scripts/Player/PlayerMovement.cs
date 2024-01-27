using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles Player movement
/// </summary>
public class PlayerMovement : MovementBase
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Inputs
        //ProcessInputs();
    }

    /// <summary>
    /// 
    /// </summary>
    private void FixedUpdate()
    {
        //Physics
        Move();
    }

    /// <summary>
    /// Handle Input (set in Unity settings)
    /// </summary>
    void ProcessInputs()
    {
        //float moveX = Input.GetAxisRaw("Horizontal");
        //float moveY = Input.GetAxisRaw("Vertical");
        //
        //moveDirection = new Vector2(moveX, moveY).normalized;
    }

    public void ProcessMovement(Vector2 moveVec)
    {
        moveDirection = moveVec.normalized;
    }

    /// <summary>
    /// Move the player via rigid body phyics
    /// </summary>
    private void Move()
    {
        rigidBody.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
