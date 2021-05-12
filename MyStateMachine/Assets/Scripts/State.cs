using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class State : ScriptableObject
{
    public bool stateAcitve = false;
    
    public AI ai;
    public abstract void StartState();
    public abstract void RunState();
    public abstract void EndState();
    private protected void RotateTowards(Transform transform, Transform target, float speed)
    {
        Vector3 targetDirection = target.position - transform.position;
        float singleStep = speed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        Debug.DrawRay(transform.position, newDirection, Color.red);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
    
}
