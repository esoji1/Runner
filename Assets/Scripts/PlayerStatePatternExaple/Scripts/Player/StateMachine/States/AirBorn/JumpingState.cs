public class JumpingState : AirBornState
{
    private JumpingStateConfig _config;

    public JumpingState(IStateSwitcher stateSwitcher, StateMachineData data, Player player) : base(stateSwitcher, data, player)
        => _config = player.Config.AirBornStateConfig.JumpingStateConfig;

    public override void Enter()
    {
        base.Enter();

        View.StartJumping();

        Data.YVelocity = _config.StartYVelocity;

    }

    public override void Exit()
    {
        base.Exit();

        View.StopJumping();
    }

    public override void Update()
    {
        base.Update();

        if (Data.YVelocity <= 0)
            StateSwitcher.SwitcherState<FallingState>();
    }
}
