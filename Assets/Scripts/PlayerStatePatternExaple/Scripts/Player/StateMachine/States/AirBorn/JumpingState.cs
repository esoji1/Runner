using UnityEngine;

public class JumpingState : AirBornState
{
    private JumpingStateConfig _config;
    private AudioSource _audioJump;
    
    public JumpingState(IStateSwitcher stateSwitcher, StateMachineData data, Player player, AudioSource audioJump) : base(stateSwitcher, data,
        player)
    {
        _config = player.Config.AirBornStateConfig.JumpingStateConfig;
        _audioJump = audioJump;
    }

    public override void Enter()
    {
        base.Enter();

        _audioJump.Play();

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
