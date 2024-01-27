using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    private LinkedList<Observer> observers;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnNotifyObservers(PlayerBase player, Event e)
    {
        LinkedListNode<Observer> observer = observers.First;
        while(observer != null)
        {
            observer.Value.OnNotify(this, e);
            observer = observer.Next;
        }
    }
}
