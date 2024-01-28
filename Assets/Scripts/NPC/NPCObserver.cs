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
                //Debug.Log("Player In Range");
                if(e.OtherColliderOwner == this.gameObject.name)
                {
                    movement.ToggleMovement(stopped : true);
                }
                break;
            case PlayerLeftInteractRange:
                if (e.OtherColliderOwner == this.gameObject.name)
                {
                    movement.ToggleMovement(stopped : false);
                }
                break;

            case BeginInteractionEvent:
                if (movement.Stopped)
                    ClownDialogueManager.ClownDialogueManagerInstance.BeginDialogue(this.GetComponent<NPCInfo>().ClownType, Location.tent, this.GetComponent<NPCInfo>());
                break;

            case EndInteractionEvent:
                if (movement.Stopped)
                    ClownDialogueManager.ClownDialogueManagerInstance.EndDialogue();
                break;

            default:
                break;
        }
    }
}
