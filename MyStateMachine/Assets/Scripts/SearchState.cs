using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Search", menuName = "ScriptableObjects/Search", order = 6)]

public class SearchState : State
{
    private float inspectTime = 0.0f;
    public override void StartState()
    {
        ai.animator.SetBool("isLookingAround", true);
    }
    public override void RunState()
    {
        if (inspectTime == 0.0f)
        {

            ai.animator.SetBool("isLookingAround", true);
        }

        inspectTime += Time.fixedDeltaTime;

        if (inspectTime >= 4.0f || ai.TargetInSight())
        {
            ai.animator.SetBool("isLookingAround", false);

            ai.StateMachine.SetParameter("Search", false);
            inspectTime = 0.0f;
        }
    }
    public override void EndState()
    {
    }
}
