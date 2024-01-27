using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles inputs
/// </summary>
public class PlayerController : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerInteraction playerInteraction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();   
    }

    /// <summary>
    /// All inputs related to the player are grabbed here
    /// </summary>
    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        if(!playerInteraction.IsInteracting)
        {
            playerMovement.ProcessMovement(new Vector2(moveX, moveY));
        }

        bool submitHit = Input.GetButtonDown("Submit");
        if (submitHit)
        {
            playerInteraction.EnterHit();
        }
    }
}
