using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Moveable))]
public class PlayerController : MonoBehaviour
{
    public InputHandler inputHandler;

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
        
    }

    private void OnSetDirection(Vector2 direction)
    {
        //Debug.Log("Test " + direction);
        moveable.setDirection(direction);
    }

    private void OnEnable()
    {
        //inputHandler.OnSetDirectionAction += OnSetDirection;
        inputHandler.OnMoveAction += OnSetDirection;
    }

    private void OnDisable()
    {
        //inputHandler.OnSetDirectionAction -= OnSetDirection;
        inputHandler.OnMoveAction -= OnSetDirection;
    }
}
