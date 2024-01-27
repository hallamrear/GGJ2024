using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderBehaviour : MoveBehaviour
{
    [Header("")]
    public float WanderRadius = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void InitialiseMovement(Vector2 pos)
    {
    }

    public override Vector2 CalculateMoveDirection(Vector2 pos)
    {
        //move to here
        Vector2 heading = new Vector2();

        return heading;
    }
}
