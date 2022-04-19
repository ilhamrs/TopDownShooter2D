using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Moveable))]
public class MoveLeftRight : MonoBehaviour
{
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
        StartCoroutine(LeftRight());
    }

    IEnumerator LeftRight()
    {
        while (true)
        {
            moveable.setXDirection(4);
            yield return new WaitForSeconds(2);
            moveable.setXDirection(-4);
            yield return new WaitForSeconds(2);
        }
        
    }
}
