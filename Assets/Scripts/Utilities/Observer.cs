using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Listener for events
/// </summary>
public abstract class Observer : MonoBehaviour
{
    /// <summary>
    /// On an event recieved from the subject
    /// </summary>
    /// <param name="player">The source of the notification</param>
    /// <param name="e">The event that took place</param>
    public abstract void OnNotify(EntityBase entity, NotifyEvent e);
}
