using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Transition", menuName = "ScriptableObjects/Transition", order = 4)]
public class Transition : ScriptableObject
{
    public State from;
    public State to;

    public Parameter parameter;
    public bool PassOnFalse;

    public bool Pass(Parameter _parameter)
    {
            if(_parameter.id == parameter.id)
            {
                if(PassOnFalse)
                {
                    if (!_parameter.Pass)
                        return true;

                }
                else
                {
                    if(_parameter.Pass)
                    return true;
                }
            }
        return false;
    }
}
