using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Punch", menuName = "ScriptableObjects/Punch", order = 3)]
public class PunchState : State
{
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
