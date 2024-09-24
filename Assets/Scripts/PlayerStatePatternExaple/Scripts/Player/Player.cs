using System;
using UnityEngine;

public class Player : MonoBehaviour, IBuffPicker, IMovable
{
    [SerializeField] private PlayerView _playerView;
    [SerializeField] private PlayerConfig _config;
    [SerializeField] private GroundChecker _groundChecker;
    private PlayerInput _input;
    private PlayerStateMachine _stateMachine;
    private StateMachineData Data;

    public event Action<float> OnSpeedChanged;

    public PlayerInput Input => _input;
    public PlayerConfig Config => _config;
    public PlayerView View => _playerView;
    public GroundChecker GroundChecker => _groundChecker;
    public Transform Transform => transform;

    [SerializeField] private float _speed = 30f;
    [SerializeField] private float horizontalSpeed = 30f;

    public float Speed => _speed;
    public float SpeedMovementHorizontal => horizontalSpeed;

    private void Awake()
    {
        Data = new StateMachineData();
        _playerView.Initialize();
        _input = new PlayerInput();
        _stateMachine = new PlayerStateMachine(this, Data);
    }

    private void Update()
    {
        _stateMachine.Update();

        _stateMachine.HandleInput();
    }

    private void OnEnable() => _input.Enable();

    private void OnDisable() => _input.Disable();

    public void AddSpeed(float speed)
    {
        OnSpeedChanged!.Invoke(speed);
        _speed += speed;
    }

    public void AddSpeedHorizonal(float speedMovementHorizontal)
    {
        Data.Speed += speedMovementHorizontal;
        horizontalSpeed += speedMovementHorizontal;
    }
}
