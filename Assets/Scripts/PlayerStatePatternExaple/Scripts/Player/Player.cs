using Assets.Scripts;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour, IBuffPicker, IMovable, IDamage
{
    [SerializeField] private PlayerView _playerView;
    [SerializeField] private PlayerConfig _config;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private DistanceTraveled _distanceTraveled;
    [SerializeField] private AudioSource _audioJump;
    [SerializeField] private AudioSource _audioHealth;
    [SerializeField] private AudioSource _audioHorizontalSpeed;
    [SerializeField] private AudioSource _audioSpeedLine;
    private PlayerInput _input;
    private PlayerStateMachine _stateMachine;
    private StateMachineData _data;
    private Health _health;

    public event Action<float> OnSpeedChanged;
    public event Action<int> OnAddHealth;
    public event Func<Buff, float, TextMeshProUGUI> OnPickedUpBuff;

    public PlayerInput Input => _input;
    public PlayerConfig Config => _config;
    public PlayerView View => _playerView;
    public GroundChecker GroundChecker => _groundChecker;
    public Transform Transform => transform;
    public int Health => _health.HealthValue;
    public AudioSource AudioJump => _audioJump;

    [SerializeField] private float _speed = 30f;
    [SerializeField] private float horizontalSpeed = 30f;

    public float Speed => _speed;
    public float SpeedMovementHorizontal => horizontalSpeed;

    private void Awake()
    {
        _health = new Health(100);
        _data = new StateMachineData();
        _distanceTraveled.Initialize(_data);
        _playerView.Initialize();
        _input = new PlayerInput();
        _stateMachine = new PlayerStateMachine(this, _data);
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
        OnSpeedChanged?.Invoke(speed);
        OnPickedUpBuff?.Invoke(Buff.BuffSpeedLine, 10f);
        _data.SpeedSlap += speed;
        _speed += _speed;
    }

    public void AddSpeedHorizonal(float speedMovementHorizontal)
    {
        OnPickedUpBuff?.Invoke(Buff.BuffHorizontalSpeed, 15f);
        _data.SpeedHorizontal += speedMovementHorizontal;
        horizontalSpeed += speedMovementHorizontal;
    }

    public void Damage(int damage)
    {
        _health.TakeDamage(damage);
    }

    public void AddHealth(int health)
    {
        OnPickedUpBuff?.Invoke(Buff.BuffAddHealth, 20f);
        OnAddHealth?.Invoke(health);
        _health.AddHealth(health);
    }

    public void AudioEffectHealth() => _audioHealth.Play();

    public void AudioEffectHorizontalSpeed() => _audioHorizontalSpeed.Play();

    public void AudioEffectSpeedLine() => _audioSpeedLine.Play();
}