using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StateMachine : MonoBehaviour
{
    public AI ai;

    [SerializeField] private List<State> states = new List<State>();
    [SerializeField] private List<Transition> transitions = new List<Transition>();
    [SerializeField] private List<Parameter> parameters = new List<Parameter>();
    public Parameter activeParameter;

    private State activeState;
    private State nextState;
    public void Start()
    {
        for(int i = 0; i < states.Count; i++)
        {
            states[i].ai = ai;
        }

        activeParameter = new Parameter();
        activeState = states[0];
        nextState = activeState;
        activeState.StartState();
    }
    public void FixedUpdate()
    {
        activeState.RunState();

        UpdateStates();
    }
    private void UpdateStates()
    {
        for(int j = 0; j < transitions.Count; j++)
        {
            for(int i = 0; i < parameters.Count; i++)
            {
                if(transitions[j].Pass(parameters[i]))
                {
                    if(transitions[j].from.GetType() == activeState.GetType())
                    {
                        if(GetState(transitions[j].to) != null)
                        {
                            nextState = (State)transitions[j].to;
                            activeParameter = parameters[i];
                        }
                    }
                }
            }
        }
      

        if (nextState != activeState)
        {
            activeState.EndState();
            nextState.StartState();
            activeState = nextState;
        }
    }
    public bool GetTransition(State _from, State _to)
    {
        for( int i = 0; i < transitions.Count; i++)
        {
            if(transitions[i].from.GetType() == _from.GetType() && transitions[i].to.GetType() == _to.GetType())
            {
                return true;
            }
        }
        return false;
    }
    private State GetState(State state)
    {
        for( int i = 0; i < states.Count; i++)
        {
            if(state.GetType() == states[i].GetType())
            {
                return states[i];
            }
        }
        return null;
    }
    public void SetParameter(string name, bool value)
    {
        for(int i = 0; i < parameters.Count; i++)
        {
            if(name == parameters[i].name)
            {
                parameters[i].Pass = value;
                Debug.Log("Cheese");
            }
        }
    }
    public bool GetActiveParameter(string name)
    {
        if (name == activeParameter.name)
        {
            return true;
        }
        return false;
    }
    public void SetParameter(Parameter parameter, bool value)
    {
        for (int i = 0; i < parameters.Count; i++)
        {
            if (parameter.id == parameters[i].id)
            {
                parameters[i].Pass = value;
                Debug.Log("Cheese");
            }
        }
    }
}
