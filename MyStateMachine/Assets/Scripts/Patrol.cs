using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : State
{
    private int nextPointNr = 0;
    private Transform nextPoint;
    public override bool isCondition()
    {
        if (!ai.TargetInSight() && !ai.TargetInAttackRange())
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
        }
        
    }
    public override void EndState()
    {
        ai.animator.SetBool("isWalking", false);
    }
    private bool Approximetley(Vector3 a, Vector3 b)
    {

        if (a.x > b.x - 0.1f && a.x < b.x + 0.1f)
        {
            if (a.y > b.y - 0.1f && a.y < b.y + 0.1f)
            {
                if (a.z > b.z - 0.1f && a.z < b.z + 0.1f)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
