using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaceBehaviour : MoveBehaviour
{
    [Header("Locations for pacing")]
    // Must have at least two
    public List<Vector2> PacingPoints;
    public float PositionRangeSqr = 100;

    private PositionNodeManager positionManager = new PositionNodeManager();
    private PositionNode CurrentHeadingNode;
    private Vector2 cachedHeadingDirection;

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
        CurrentHeadingNode = positionManager.BetterNodeCreation(PacingPoints);
        cachedHeadingDirection = CurrentHeadingNode.Position - pos;
    }

    public override Vector2 CalculateMoveDirection(Vector2 pos)
    {
        if((pos - CurrentHeadingNode.Position).sqrMagnitude < PositionRangeSqr)
        {
            CurrentHeadingNode = CurrentHeadingNode.NextPositionNode;

            return CurrentHeadingNode.Position - pos;
        }
        else
        {
            return CurrentHeadingNode.Position - pos;
        }
    }
}
