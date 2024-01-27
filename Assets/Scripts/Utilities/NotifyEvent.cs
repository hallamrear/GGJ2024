using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Location available in game
/// </summary>
public enum Location
{
    circus,
    tent,
    restaurant,
    coffeeShop,
}


/// <summary>
/// Base class for the notify events for the observer system
/// </summary>
public class NotifyEvent
{
    public Location location;
    public string OtherColliderOwner;

}

/// <summary>
/// Lets npc know player is within interaction range
/// </summary>
public class PlayerEnteredInteractRange : NotifyEvent
{
}

/// <summary>
/// Lets npc know player has left range
/// </summary>
public class PlayerLeftInteractRange : NotifyEvent
{
}

/// <summary>
/// Send a message to the UI from player
/// </summary>
public class PromptUIBaseEvent : NotifyEvent
{
}





/// <summary>
/// Start the dialogue event
/// </summary>
public class BeginInteractionEvent : NotifyEvent
{
}

/// <summary>
/// End of the dialogue event
/// </summary>
public class EndInteractionEvent : NotifyEvent
{
}