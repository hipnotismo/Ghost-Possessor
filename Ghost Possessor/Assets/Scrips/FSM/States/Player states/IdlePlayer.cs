using UnityEngine;

public class IdlePlayer:BaseState
{
    private PlayerController player;

    public IdlePlayer(FiniteStateMachine fsm, PlayerController player) : base(fsm, player.gameObject)
    {
        this.player = player;
        playerState = PlayerState.idle;
    }
    [SerializeField] private KeyCode shootKey = KeyCode.V;
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;

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

        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (moveInput != Vector2.zero)
        {
            fsm.ChangeTo(PlayerState.walk);
        }
        if (Input.GetKeyDown(shootKey))
        {
            fsm.ChangeTo(PlayerState.water);
        }
        if (Input.GetKeyUp(jumpKey) && player.currentJumps < player.maxJumps)
        {
            fsm.ChangeTo(PlayerState.jump);
        }
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
