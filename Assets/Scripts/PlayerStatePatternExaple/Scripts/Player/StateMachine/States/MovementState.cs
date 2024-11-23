using UnityEngine;

public abstract class MovementState : IState
{
    protected readonly IStateSwitcher StateSwitcher;
    protected readonly StateMachineData Data;
    private readonly Player _player;

    public MovementState(IStateSwitcher stateSwitcher, StateMachineData data, Player player)
    {
        StateSwitcher = stateSwitcher;
        Data = data;
        _player = player;
    }

    protected PlayerInput Input => _player.Input;
    protected PlayerView View => _player.View;

    public virtual void Enter()
    {
        Debug.Log(GetType());
    }

    public virtual void Exit()
    {
    }

    public void HandleInput()
    {
        Data.ZInput = ReadHorizontalInput();
        Data.ZVelocity = Data.ZInput * Data.SpeedHorizontal;
    }


    public virtual void Update()
    {
        Vector3 velocity = GetConvertedVelocity();

        _player.Transform.Translate(velocity * Time.deltaTime);
    }

    protected bool IsHorizontalInputZero() => Data.ZInput == 0;

    private Vector3 GetConvertedVelocity() => new Vector3(0, Data.YVelocity, -Data.ZVelocity);

    private float ReadHorizontalInput() => Input.Movement.Move.ReadValue<float>();
}
