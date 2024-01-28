using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles Player interaction
/// </summary>
public class PlayerInteraction : Subject
{
    public BoxCollider2D boxCollider2D;

    public bool IsInteracting
    {
        get { return isInInteraction; }
    }

    private bool IsInRange = false;
    private bool isInInteraction = false;

    private PlayerEnteredInteractRange enteredInteractRangeEvent = new PlayerEnteredInteractRange();
    private PlayerLeftInteractRange leftInteractRange = new PlayerLeftInteractRange();
    private BeginInteractionEvent beginInteractionEvent = new BeginInteractionEvent();
    private EndInteractionEvent endInteractionEvent = new EndInteractionEvent();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void EnterHit()
    {
        if(IsInRange)
        {
            if(isInInteraction)
            {
                // TEMPORARY exit interaction
                isInInteraction = false;
                OnNotifyObservers(null, endInteractionEvent);
            }
            else
            {
                //Start Interaction
                //Debug.Log("Player Start Interaction");
                isInInteraction = true;
                OnNotifyObservers(null, beginInteractionEvent);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("collision entered");
        IsInRange = true;
        enteredInteractRangeEvent.OtherColliderOwner = collision.name;
        OnNotifyObservers(null, enteredInteractRangeEvent);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("collision exit");
        IsInRange = false;
        leftInteractRange.OtherColliderOwner = collision.name;
        OnNotifyObservers(null, leftInteractRange);
    }
}
