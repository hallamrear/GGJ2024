using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderBehaviour : MoveBehaviour
{
    [Header("")]
    public float WanderRadiusSq = 40;
    public Vector2 WanderCenterPoint;

    private Vector2 heading;

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
        heading = Random.insideUnitCircle;
    }

    public override Vector2 CalculateMoveDirection(Vector2 pos)
    {
        if ((pos - WanderCenterPoint).sqrMagnitude > WanderRadiusSq)
        {
            //random new direction
            heading = Random.insideUnitCircle;
            return heading;
        }
        else
        {
            return heading;
        }
    }
}
