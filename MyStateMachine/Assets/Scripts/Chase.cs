using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Chase : State
{
    
    public override bool isCondition()
    {
        if(ai.TargetInSight() && !ai.TargetInAttackRange())
            return true;
        else
            return false;
    }
    public override void StartState()
    {
        ai.animator.SetBool("isRunning", true);
    }
    public override void RunState()
    {
        Vector3 direction = ai.transform.position - ai.targetTransform.position;
        ai.transform.position -= direction.normalized * Time.fixedDeltaTime * 2;
        RotateTowards(ai.transform, ai.targetTransform, 4f);
    }
    public override void EndState()
    {
        ai.animator.SetBool("isRunning", false);
    }
}