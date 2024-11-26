using UnityEngine;

public class RunBackAndForth : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private float _leftLimit = 0f;
    private float _rightLimit = 110;
    private bool _isMovingLeft = true;

    private void Update()
    {
        if (_isMovingLeft)
            MoveToLeft();
        else
            MoveToRight();
    }

    private void MoveToLeft()
    {
        transform.position += Vector3.left * Time.deltaTime * _speed;

        if (transform.position.x <= _leftLimit)
        {
            transform.position = new Vector3(_leftLimit, transform.position.y, transform.position.z);
            _isMovingLeft = false;
        }
    }

    private void MoveToRight()
    {
        transform.position += Vector3.right * Time.deltaTime * _speed;

        if (transform.position.x >= _rightLimit)
        {
            transform.position = new Vector3(_rightLimit, transform.position.y, transform.position.z);
            _isMovingLeft = true;
        }
    }
}