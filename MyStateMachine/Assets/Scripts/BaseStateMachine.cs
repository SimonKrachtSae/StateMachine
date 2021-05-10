using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStateMachine 
{
    private AI ai;
    private List<State> states = new List<State>();
    private State activeState;
    private State nextState;

    private Patrol patrol;
    private Chase chase;
    private Punch punch;

    public BaseStateMachine(AI _ai)
    {
        ai = _ai;
    }

 
    public void AddStates()
    {

        patrol = new Patrol();
        chase = new Chase();
        punch = new Punch();

        AddState(patrol);
        AddState(chase);
        AddState(punch);
        patrol.AddTransition(chase);
        patrol.AddTransition(punch);
        chase.AddTransition(patrol);
        chase.AddTransition(punch);
        punch.AddTransition(chase);
        punch.AddTransition(patrol);

        for(int i = 0; i < states.Count; i++)
        {
            states[i].ai = ai;
        }

        activeState = patrol;
        nextState = activeState;
        activeState.StartState();
    }
    public void RunStates()
    {
        activeState.RunState();

        StatesManager();
    }
    private void StatesManager()
    {
        for(int i = 0; i < states.Count; i++)
        {
            if(states[i].isCondition())
            {
                if(activeState.ContainsTransition(states[i]))
                {
                    nextState = states[i];
                }
            }
        }

        if (nextState != activeState)
        {
            if(activeState.ContainsTransition(nextState))
            {
                activeState.EndState();
                nextState.StartState();
                activeState = nextState;
            }
        }
    }
    private void AddState(State state)
    {
        if (states == null)
            return;
        if (states.Contains(state))
            return;
        if (ContainsType(state))
            return;

        states.Add(state);
    }
    private bool ContainsType(State state)
    {
        for(int i = 0; i < states.Count; i++)
        {
            if (states[i].GetType() == state.GetType())
            {
                return true;
            }
        }
        return false;
    }
}
