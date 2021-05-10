using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public abstract class State 
{
    public bool stateAcitve = false;
    
    public List<State> transitions = new List<State>();
    public AI ai;
    public abstract bool isCondition();
    public abstract void StartState();
    public abstract void RunState();
    public abstract void EndState();
    public void AddTransition(State state)
    {
        if (transitions == null)
            return;
        for(int i = 0; i < transitions.Count; i++)
        {
            if (state.GetType() == transitions[i].GetType())
                return;
        }
        transitions.Add(state);
    }
    public bool ContainsTransition(State state)
    {
        for(int i = 0; i < transitions.Count; i++)
        {
            if(transitions[i].GetType() == state.GetType())
            {
                return true;
            }    
        }
        Debug.Log("Couldnt get type");
        return false;
    }
    private protected void RotateTowards(Transform transform, Transform target, float speed)
    {
        Vector3 targetDirection = target.position - transform.position;
        float singleStep = speed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        Debug.DrawRay(transform.position, newDirection, Color.red);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
