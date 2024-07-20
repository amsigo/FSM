using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSMState<T>
{
    protected T root;

    public FSMState(T root)
    {
        this.root = root;
    }

    public abstract void OnEnter();
    public abstract void OnUpdate();
    public abstract void OnExit();
}
