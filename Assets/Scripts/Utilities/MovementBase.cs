using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBase : MonoBehaviour
{
    [Header("Physics")]
    public Rigidbody2D rigidBody;

    [Header("Move stats")]
    public float moveSpeed = 5;
    public Vector2 headingDirection = new Vector2(0, 1);

    protected Vector2 moveDirection = new Vector2(0, 0);


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
