using UnityEngine;

public abstract class BaseState 
{
    public PlayerState playerState = PlayerState.None;
    protected FiniteStateMachine fsm;
    protected GameObject stateObject;

    public BaseState( FiniteStateMachine fsm, GameObject stateObject) {  this.fsm = fsm; this.stateObject = stateObject; }
    public abstract void Init();
    
    public virtual void OnEnter()
    {
        Debug.Log("We are on enter");
    }

    public virtual void OnUpdate()
    {
        Debug.Log("We are on update");

    }

    public virtual void OnExit()
    {
        Debug.Log("We are on exit");

    }
}
