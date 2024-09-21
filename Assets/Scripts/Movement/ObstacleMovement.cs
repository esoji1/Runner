using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private Transform _obstacle;
    [SerializeField] private float _speed = 30f;
    [SerializeField] private Player _player;

    private void Update()
    {
        Move();
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

    public void Move()
    {
        Vector3 moveAtCertainSpeed = new Vector3(_speed, 0, 0);
        transform.Translate(moveAtCertainSpeed * Time.deltaTime);
    }

    private void OnSpeedChanged(float speed)
    {
        _speed += speed;
    }
}
