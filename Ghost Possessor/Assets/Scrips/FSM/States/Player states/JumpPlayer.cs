
using Unity.VisualScripting;
using UnityEngine;

public class JumpPlayer:BaseState
{
    private PlayerController player;

    public JumpPlayer(FiniteStateMachine fsm, PlayerController player) : base(fsm, player.gameObject)
    {
        this.player = player;
        playerState = PlayerState.jump;
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
  
        //if (/*player.isGrounded == true &&*/ player.currentJumps < player.maxJumps)
        //{
            player.rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
            player.currentJumps++;
        //}

        //if(player.isGrounded == true)
        fsm.ChangeTo(PlayerState.idle);

    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
