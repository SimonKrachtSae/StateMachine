using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    public static AIManager Instance;
    private List<AI> activeAIs = new List<AI>();
    public Transform targetTransform;
    protected virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void Subscribe(AI ai)
    {
        if (activeAIs == null)
            return;
        if (activeAIs.Contains(ai))
            return;

        ai.targetTransform = targetTransform;
        activeAIs.Add(ai);
    }
    public void UnSubscribe(AI ai)
    {
        if (activeAIs == null)
            return;
        activeAIs.Remove(ai);
    }
}
