using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : State
{
    public override bool isCondition()
    {
        if(ai.TargetInAttackRange())
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public override void StartState()
    {
        ai.animator.SetBool("isPunching", true);
        ai.transform.position += (ai.targetTransform.position - ai.transform.position).normalized * 0.3f;
    }
    public override void RunState()
    {
        RotateTowards(ai.transform, ai.targetTransform, 2);
    }
    public override void EndState()
    {
        ai.animator.SetBool("isPunching", false);

    }
}
