using UnityEngine;

public class IdlePlayer:BaseState
{
    private PlayerController2 player;

    public IdlePlayer(FiniteStateMachine fsm, PlayerController2 player) : base(fsm, player.gameObject)
    {
        this.player = player;
        playerState = PlayerState.idle;
    }
    [SerializeField] private KeyCode shootKey = KeyCode.V;

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
            fsm.ChangeTo(PlayerState.jump);
        }
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
