using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Circular Linked list for wander behaviour
/// </summary>
public class PositionNode
{
    public PositionNode(Vector2 pos)
    {
        Position = pos;
    }

    public Vector2 Position;

    public PositionNode NextPositionNode;
}

public class PositionNodeManager
{
    PositionNode headNode;
    public PositionNode BetterNodeCreation(List<Vector2> points)
    {
        headNode = new PositionNode(points[0]);
        points.RemoveAt(0);
        CreateNode(headNode, points);
        return headNode;
    }

    public void CreateNode(PositionNode previousNode, List<Vector2> points)
    {
        if(points.Count !=0)
        {
            PositionNode newNode = new PositionNode(points[0]);
            previousNode.NextPositionNode = newNode;

            points.RemoveAt(0);

            CreateNode(newNode, points);
        }
        else
        {
            previousNode.NextPositionNode = headNode;
        }
    }
}




public abstract class MoveBehaviour : MonoBehaviour
{
    public bool Active = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract Vector2 CalculateMoveDirection(Vector2 pos);

    public abstract void InitialiseMovement(Vector2 pos);
}
