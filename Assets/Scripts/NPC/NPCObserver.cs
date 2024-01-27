using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// NPCs observer for listening and processing npc events
/// </summary>
public class NPCObserver : Observer
{
    public NPCMovement movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnNotify(EntityBase entity, NotifyEvent e)
    {
        // Begin interaction
        switch(e)
        {
            case PlayerEnteredInteractRange:
                Debug.Log("Player In Range");
                movement.ToggleMovement();
                // Stop moving
                    break;
            case PlayerLeftInteractRange:
                // contiue moving
                movement.ToggleMovement();
                break;

            case BeginInteractionEvent:
                //Debug.Log("Interaction Started");

                break;

            case EndInteractionEvent:
                break;

            default:
                break;
        }
    }
}
