using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PoolObjectType
{
    BULLET, BOLT, EXPLOSION
}
public class PoolObject : MonoBehaviour
{
    public PoolObjectType type;
    // Start is called before the first frame update
    void Start()
    {
        deactivate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activate(Vector3 pos, Quaternion rotation)
    {
        gameObject.SetActive(true);
        transform.position = pos;
        transform.rotation = rotation;
    }

    public void deactivate()
    {
        gameObject.SetActive(false);
    }

    internal bool isActive()
    {
        return gameObject.activeInHierarchy;
    }
}
