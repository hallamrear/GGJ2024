using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour
{
    public List<Observer> observers;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Notify the observers that an event occured
    /// </summary>
    /// <param name="player"></param>
    /// <param name="e"></param>
    protected void OnNotifyObservers(EntityBase entity, NotifyEvent e)
    {
        foreach (Observer observer in observers)
        {
            observer.OnNotify(entity, e);
        }
    }
}
