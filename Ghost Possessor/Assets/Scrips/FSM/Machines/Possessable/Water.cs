using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : FiniteStateMachine
{
    public override void Initialize(List<BaseState> states)
    {
        state.Add(new WaterAbility(this, player));
        currentState = state[0];
    }
}
