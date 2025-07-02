using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAbility : BaseState
{
    private PlayerController2 player;

    public WaterAbility(FiniteStateMachine fsm, PlayerController2 player) : base(fsm, player.gameObject)
    {
        this.player = player;
        playerState = PlayerState.water;
    }

    public override void Init()
    {

    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnUpdate()
    {
        Debug.Log("ABILITY WATER");
       
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
