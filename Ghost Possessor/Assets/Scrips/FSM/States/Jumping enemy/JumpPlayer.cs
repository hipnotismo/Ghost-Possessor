
public class JumpPlayer:BaseState
{
    public JumpPlayer(FiniteStateMachine fsm) : base(fsm)
    {

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
