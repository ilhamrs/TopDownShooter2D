using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Moveable))]
public class MovementBoundary : MonoBehaviour
{
    public Rect boundary;

    private Moveable moveable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        moveable = GetComponent<Moveable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isXOutOfBoundary())
        {
            moveable.setXDirection(0f);
        }

        if (isYOutOfBoundary())
        {
            moveable.setYDirection(0f);
        }
    }

    private bool isYOutOfBoundary()
    {
        return moveable.getNextPosition().y < boundary.yMin || moveable.getNextPosition().y > boundary.yMax;
    }

    private bool isXOutOfBoundary()
    {
        return moveable.getNextPosition().x < boundary.xMin || moveable.getNextPosition().x > boundary.xMax;
    }
}
