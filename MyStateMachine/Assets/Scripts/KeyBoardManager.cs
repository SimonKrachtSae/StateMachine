using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardManager : MonoBehaviour
{
    public static KeyBoardManager Instance;
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
    public bool IsMoving()
    {
        if (ForwardPressed() || BackwardPressed() || LeftPressed() || RightPressed())
            return true;
        else
            return false;
    }
    public bool ForwardPressed()
    {
        if (Input.GetKey(KeyCode.W))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool BackwardPressed()
    {
        if (Input.GetKey(KeyCode.S))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool RightPressed()
    {
        if (Input.GetKey(KeyCode.D))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool LeftPressed()
    {
        if (Input.GetKey(KeyCode.A))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
