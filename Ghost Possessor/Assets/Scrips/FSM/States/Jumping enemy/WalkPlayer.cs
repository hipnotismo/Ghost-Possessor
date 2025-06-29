using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkPlayer : BaseState
{
    public WalkPlayer(FiniteStateMachine fsm) : base(fsm)
    {

    }
    public override void Init()
    {
        playerState = PlayerState.idle;
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
