using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _speed = 30;

    private void Update()
    {
        Movement();
    }

    private void OnEnable()
    {
        if (_player != null)
        {
            _player.OnSpeedChanged += OnSpeedChanged;
        }
    }

    private void OnDisable()
    {
        if (_player != null)
        {
            _player.OnSpeedChanged -= OnSpeedChanged;
        }
    }

    public void Movement()
    {
        Vector3 moveDirection = new Vector3(_speed, 0, 0);
        _player.Transform.Translate(moveDirection * Time.deltaTime);
    }

    private void OnSpeedChanged(float speed)
    {
        _speed += speed;
    }
}
