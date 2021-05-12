using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[CreateAssetMenu(fileName = "Chase", menuName = "ScriptableObjects/Chase", order = 2)]
public class ChaseState : State
{
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