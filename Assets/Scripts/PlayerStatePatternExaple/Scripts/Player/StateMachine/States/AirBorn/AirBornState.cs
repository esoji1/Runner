using UnityEngine;

public class AirBornState : MovementState
{
    private AirBornStateConfig _config;

    public AirBornState(IStateSwitcher stateSwitcher, StateMachineData data, Player player) : base(stateSwitcher, data, player)
        => _config = player.Config.AirBornStateConfig;

    public override void Enter()
    {
        base.Enter();

        View.StartAirborne();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopAirborne();
    }

    public override void Update()
    {
        base.Update();

        Data.YVelocity -= _config.BaseGravity * Time.deltaTime; 
    }
}
