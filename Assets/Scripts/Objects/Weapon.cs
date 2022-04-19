using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float fireRate;
    public List<float> fireRateModifiers;
    public PoolObjectType type;

    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        fireRateModifiers = new List<float>();
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer - Time.deltaTime > 0 ? timer - Time.deltaTime : 0f;
    }

    public void shoot()
    {
        if (timer == 0)
        {
            //Debug.Log("Tembak!");
            ObjectPool.GetInstance().requestObject(type).activate(transform.position, transform.rotation);
            timer = fireRate / getFireRateModifier();
        }
        
    }

    private float getFireRateModifier()
    {
        float mod = 1;

        foreach(float f in fireRateModifiers)
        {
            mod += f;
        }

        return mod;
    }

    internal void addFireRateModifier(float modifier)
    {
        fireRateModifiers.Add(modifier);
    }

    internal void removeFireRateModifier(float modifier)
    {
        fireRateModifiers.Remove(modifier);
    }

    internal void clearModifier()
    {
        fireRateModifiers.Clear();
    }
}
