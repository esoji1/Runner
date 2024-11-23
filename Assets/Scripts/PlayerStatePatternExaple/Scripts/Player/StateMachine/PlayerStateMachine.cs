using System.Collections.Generic;
using System.Linq;

public class PlayerStateMachine : IStateSwitcher
{
    private List<MovementState> _states;
    private MovementState _currentState;

    public PlayerStateMachine(Player player, StateMachineData data)
    {
        _states = new List<MovementState>()
        {
            new IdleState(this, data, player),
            new RunningState(this, data, player),
            new JumpingState(this, data, player, player.AudioJump),
            new FallingState(this, data, player),
        };

        _currentState = _states[0];
        _currentState.Enter();
    }

    public void SwitcherState<T>() where T : MovementState
    {
        MovementState state = _states.FirstOrDefault(state => state is T);

        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    public void HandleInput() => _currentState.HandleInput();

    public void Update() => _currentState.Update();
}
