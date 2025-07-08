using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WalkPlayer : BaseState
{
    private PlayerController player;

    public WalkPlayer(FiniteStateMachine fsm, PlayerController player) : base(fsm, player.gameObject)
    {
        this.player = player;
        playerState = PlayerState.walk;
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
        base.OnUpdate();
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 camForward = player.cameraTransform.transform.forward;

        camForward.y = 0f;
        camForward.Normalize();

        Vector3 camRight = player.cameraTransform.transform.right;
        camRight.y = 0f;
        camRight.Normalize();

        Vector3 moveDir = (camForward * v + camRight * h).normalized;
        Vector3 velocity = new Vector3(moveDir.x * player.moveSpeed, player.rb.velocity.y, moveDir.z * player.moveSpeed);

        if (CanMove(moveDir))
            player.rb.velocity = velocity;
       
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (moveInput == Vector2.zero)
        {
            fsm.ChangeTo(PlayerState.idle);
        }
    }

    private bool CanMove(Vector3 moveDir)
    {
        Terrain terrain = Terrain.activeTerrain;
        Vector3 relativePos = GetMapPos();
        Vector3 normal = terrain.terrainData.GetInterpolatedNormal(relativePos.x, relativePos.z);
        float angle = Vector3.Angle(normal, Vector3.up);

        float currentHeight = terrain.SampleHeight(player.rb.position);
        float nextHeight = terrain.SampleHeight(player.rb.position + moveDir * 5);


        if (angle > player.maxAngleMovement && nextHeight > currentHeight)
            return false;
        return true;
    }

    private Vector3 GetMapPos()
    {
        Vector3 pos = player.rb.position;
        Terrain terrain = Terrain.activeTerrain;

        return new Vector3((pos.x - terrain.transform.position.x) / terrain.terrainData.size.x,
                           0,
                           (pos.z - terrain.transform.position.z) / terrain.terrainData.size.z);
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
