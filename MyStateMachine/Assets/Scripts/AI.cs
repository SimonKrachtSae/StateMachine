using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AI : MonoBehaviour
{
    public List<Transform> patrolPoints;
    public Transform targetTransform;
    public Animator animator;
    private BaseStateMachine baseStateMachine;
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        baseStateMachine = new BaseStateMachine(this);
    }
    private void OnDestroy()
    {
        AIManager.Instance.UnSubscribe(this);
    }
    private void Start()
    {
        AIManager.Instance.Subscribe(this);
        baseStateMachine.AddStates();
    }
    private void Update()
    {
        baseStateMachine.RunStates();
    }
    public bool TargetInSight()
    {
        float lookOutRange = 10;
        if ((targetTransform.position - transform.position).magnitude <= lookOutRange && !TargetInAttackRange())
            return true;
        else
            return false;
    }
    public bool TargetInAttackRange()
    {
        if ((targetTransform.position - transform.position).magnitude <= 1.25f)
            return true;
        else
            return false;
    }
}
