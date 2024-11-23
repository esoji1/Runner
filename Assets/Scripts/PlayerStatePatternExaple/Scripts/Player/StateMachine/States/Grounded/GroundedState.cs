using UnityEngine.InputSystem;

public abstract class GroundedState : MovementState
{
    private GroundChecker _groundChecker;

    public GroundedState(IStateSwitcher stateSwitcher, StateMachineData data, Player player) : base(stateSwitcher, data, player)
        => _groundChecker = player.GroundChecker;

    public override void Enter()
    {
        base.Enter();

        Input.Movement.Jump.started += OnJumpKeyPressed;

        View.StartGrounded();
    }

    public override void Exit()
    {
        base.Exit();

        Input.Movement.Jump.started -= OnJumpKeyPressed;

        View.StopGrounded();
    }

    public override void Update()
    {
        base.Update();

        if (_groundChecker.IsTouches == false)
            StateSwitcher.SwitcherState<FallingState>();
    }

    private void OnJumpKeyPressed(InputAction.CallbackContext context)
        => StateSwitcher.SwitcherState<JumpingState>();
}
