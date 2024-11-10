public class FallingState : AirBornState
{
    private GroundChecker _groundChecker;

    public FallingState(IStateSwitcher stateSwitcher, StateMachineData data, Player player) : base(stateSwitcher, data, player)
        => _groundChecker = player.GroundChecker;

    public override void Enter()
    {
        base.Enter();

        View.StartFalling();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopFalling();
    }

    public override void Update()
    {
        base.Update();

        if(_groundChecker.IsTouches)
        {
            Data.YVelocity = 0;

            if (IsHorizontalInputZero() == false)
                StateSwitcher.SwitcherState<IdleState>();
            else
                StateSwitcher.SwitcherState<RunningState>();
        }
    }
}
