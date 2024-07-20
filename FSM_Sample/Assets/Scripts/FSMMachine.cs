using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMMachine<T>
{
    Dictionary<System.Enum, FSMState<T>> fsmStateDict = new Dictionary<System.Enum, FSMState<T>>();

    private System.Enum currentState;
    public System.Enum CurrentState => currentState;

    public void RegistState(System.Enum eState, FSMState<T> fsmState)
    {
        if (fsmStateDict.ContainsKey(eState))
            return;

        fsmStateDict.Add(eState, fsmState);
    }

    public void FSMStart(System.Enum startState)
    {
        if (fsmStateDict.ContainsKey(startState))
        {
            currentState = startState;

            fsmStateDict[currentState].OnEnter();
        }
    }

    public void UpdateFSM()
    {
        if (currentState == null)
            return;

        if (!fsmStateDict.ContainsKey(currentState))
            return;

        fsmStateDict[currentState].OnUpdate();
    }

    public void ChangeState(System.Enum newState)
    {
        if (currentState.Equals(newState))
            return;

        if (!fsmStateDict.ContainsKey(newState))
            return;

        fsmStateDict[currentState].OnExit();

        currentState = newState;

        fsmStateDict[currentState].OnEnter();
    }
}