using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SampleState
{ 
    AState = 0,
    BState,
    CState
}

public class SampleFSM : MonoBehaviour
{
    FSMMachine<SampleFSM> fsm = new FSMMachine<SampleFSM>();

    private void Awake()
    {
        //FSM State µî·Ï
        fsm.RegistState(SampleState.AState, new AState(this));
        fsm.RegistState(SampleState.BState, new BState(this));
        fsm.RegistState(SampleState.CState, new CState(this));

        fsm.FSMStart(SampleState.AState);
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.A))
        {
            fsm.ChangeState(SampleState.AState);
        }

        else if (Input.GetKeyUp(KeyCode.B))
        {
            fsm.ChangeState(SampleState.BState);
        }

        else if (Input.GetKeyUp(KeyCode.C))
        {
            fsm.ChangeState(SampleState.CState);
        }

        fsm.UpdateFSM();
    }
}

public class AState : FSMState<SampleFSM>
{
    public AState(SampleFSM sampleFSM) : base(sampleFSM)
    {

    }

    public override void OnEnter()
    {
        Debug.Log("AState - OnEnter");
    }
    public override void OnUpdate()
    {
        Debug.Log("AState - OnUpdate");
    }

    public override void OnExit()
    {
        Debug.Log("AState - OnExit");
    }
}
public class BState : FSMState<SampleFSM>
{
    public BState(SampleFSM sampleFSM) : base(sampleFSM)
    {

    }

    public override void OnEnter()
    {
        Debug.Log("BState - OnEnter");
    }
    public override void OnUpdate()
    {
        Debug.Log("BState - OnUpdate");
    }

    public override void OnExit()
    {
        Debug.Log("BState - OnExit");
    }
}

public class CState : FSMState<SampleFSM>
{
    public CState(SampleFSM sampleFSM) : base(sampleFSM)
    {

    }

    public override void OnEnter()
    {
        Debug.Log("CState - OnEnter");
    }
    public override void OnUpdate()
    {
        Debug.Log("CState - OnUpdate");
    }

    public override void OnExit()
    {
        Debug.Log("CState - OnExit");
    }
}