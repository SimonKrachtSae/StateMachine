using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AI : MonoBehaviour
{
    public static AI Instance;

    public List<Transform> patrolPoints;
    public Transform targetTransform;
    public Animator animator;
    public StateMachine StateMachine;
    public Sight sight;
    public bool searching = false;
    public bool chasing = false;
    private void OnDestroy()
    {
        AIManager.Instance.UnSubscribe(this);
    }
    private void Start()
    {
        sight = GetComponentInChildren<Sight>();
        StateMachine = transform.GetComponent<StateMachine>();
        AIManager.Instance.Subscribe(this);
    }
    private void Update()
    {

        TargetInAttackRange();

        if(TargetInSight())
        {
            chasing = true;
            StateMachine.SetParameter("TargetInSight", true);
        }
        else if(chasing)
        {
            chasing = false;
            StateMachine.SetParameter("TargetInSight",false);
        }

    }
    public bool TargetInSight()
    {
        if(sight.targetInSight && !TargetInAttackRange())
            return true;
        else
            return false;
    }
    public bool TargetInAttackRange()
    {
        if ((targetTransform.position - transform.position).magnitude <= 1.25f)
        {
            StateMachine.SetParameter("TargetInAttackRange", true);
            return true;
        }
        else
        {
            StateMachine.SetParameter("TargetInAttackRange", false);
            return false;
        }
    }

}
