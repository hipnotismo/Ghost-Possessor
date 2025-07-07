using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine 
{
    public BaseState currentState ;
    

    public List<BaseState> state = new List<BaseState>(); 
    public PlayerController player;
    public virtual void Initialize()
    {
        
        state.Add(new IdlePlayer(this,player));
        state.Add(new WalkPlayer(this, player));
        currentState = state[0];
    }

    public virtual void Initialize(List<BaseState> states)
    {
        state = states;
        currentState = state[0];
    }

    public void GetPlayer(PlayerController controller)
    {
        player = controller;
    }
    public void OnUpdate()
    {
        currentState.OnUpdate();
    }

    public void ChangeTo(PlayerState enemyStates)
    {
        currentState.OnExit();
        currentState = FindState(enemyStates);
        currentState.OnEnter();

    }

    public BaseState FindState(PlayerState enemyStates) 
    {
        foreach (BaseState state in state) 
            if (state.playerState == enemyStates)
                return state;
        return currentState;
    }
}
