using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles Player interaction
/// </summary>
public class PlayerInteraction : MonoBehaviour
{
    public BoxCollider2D boxCollider2D;

    public List<Observer> observers;

    private bool IsInRange = false;
    private bool IsInInteraction = false;

    private PlayerEnteredInteractRange enteredInteractRangeEvent = new PlayerEnteredInteractRange();
    private PlayerLeftInteractRange leftInteractRange = new PlayerLeftInteractRange();
    private BeginInteractionEvent beginInteractionEvent = new BeginInteractionEvent();
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
            if(IsInInteraction)
            {
                // do nothing
            }
            else
            {
                //Start Interaction
                //Debug.Log("Player Start Interaction");
                OnNotifyObservers(null, beginInteractionEvent);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsInRange = true;
        //Debug.Log("collision entered");


        OnNotifyObservers(null, enteredInteractRangeEvent);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsInRange = false;
        //Debug.Log("collision exit");

        OnNotifyObservers(null, leftInteractRange);

    }


    /// <summary>
    /// Notify the observers that an event occured
    /// </summary>
    /// <param name="player"></param>
    /// <param name="e"></param>
    void OnNotifyObservers(EntityBase entity, NotifyEvent e)
    {
        foreach(Observer observer in observers)
        {
            observer.OnNotify(entity, e);
        }
    }
}
