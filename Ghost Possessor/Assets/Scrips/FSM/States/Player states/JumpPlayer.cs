
public class JumpPlayer:BaseState
{
    private PlayerController2 player;

    public JumpPlayer(FiniteStateMachine fsm, PlayerController2 player) : base(fsm, player.gameObject)
    {
        this.player = player;
    }

    public override void Init()
    {
        playerState = PlayerState.jump;
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
