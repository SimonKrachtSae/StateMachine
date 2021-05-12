using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Parameter", menuName = "ScriptableObjects/Parameter", order = 5)]
public class Parameter : ScriptableObject
{
    public string id;
    public bool Pass;
}
