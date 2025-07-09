using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterStates : BaseStateList
{
    public override List<BaseState> Initialize(FiniteStateMachine machine, PlayerController player)
    {
        Debug.Log("WE GOT TO WATER");
        List<BaseState> state = new List<BaseState>();
        state.Add(new IdlePlayer(machine, player));
        state.Add(new WalkPlayer(machine, player));
        state.Add(new WaterAbility(machine, player));
        return state;
    }

    public void EndOfAbilityAnimaion()
    {
        PlayerController player = GetComponent<PlayerController>();

        player.animator.SetBool("Water", false);

    }
}
