public class IdleState : GroundedState
{
    public IdleState(IStateSwitcher stateSwitcher, StateMachineData data, Player player) : base(stateSwitcher, data, player)
    {
    }

    public override void Enter()
    {
        base.Enter();

        View.StartIdling();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopIdling();
    }

    public override void Update()
    {
        base.Update();

        if (IsHorizontalInputZero())
            return;

        StateSwitcher.SwitcherState<RunningState>();
    }
}
