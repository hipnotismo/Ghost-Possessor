using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAbility : BaseState
{
    private PlayerController player;

    public WaterAbility(FiniteStateMachine fsm, PlayerController player) : base(fsm, player.gameObject)
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
        RaycastHit hit;

        Vector3 spawnPosition = player.transform.position;
        Vector3 spawnDirection = player.transform.forward;

        if (Physics.Raycast(spawnPosition, spawnDirection, out hit, 5f))
        {

            IInteractable isHit = hit.collider.GetComponent<IInteractable>();

            if (isHit != null)
            {
                Debug.Log("GOT A HIT");

                isHit.Interaction("water");
            }

        }
        player.animator.SetBool("Water", true);

        fsm.ChangeTo(PlayerState.idle);

    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
