using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Patrol", menuName = "ScriptableObjects/Patrol", order = 1)]
public class PatrolState : State
{
    private int nextPointNr = 0;
    private Transform nextPoint;

    public override void StartState()
    {
        ai.animator.SetBool("isWalking", true);
    }
    public override void RunState()
    {
        Vector3 moveDir;

        nextPoint = ai.patrolPoints[nextPointNr];

        moveDir = nextPoint.position - ai.transform.position;
        ai.transform.position += moveDir.normalized * Time.deltaTime * 1.5f;
        RotateTowards(ai.transform, nextPoint, 2f);


        if(Approximetley(ai.transform.position,nextPoint.position))
        {
            nextPointNr++;
            if(nextPointNr == ai.patrolPoints.Count)
            {
                nextPointNr = 0;
            }
            ai.StateMachine.SetParameter("Search", true);
        }
        
    }
    public override void EndState()
    {
        ai.animator.SetBool("isWalking", false);
    }
    private bool Approximetley(Vector3 a, Vector3 b)
    {

        if ((a - b).magnitude < 0.2f )
        {
            return true;
        }
        return false;
    }
}
