using System;
using UnityEngine;

public class ObstacleDetection : MonoBehaviour
{
    [SerializeField] private Player _player;  
    [SerializeField] private LossView _lossView;
    [SerializeField] private GameObject _pfefabDestroy;
    [SerializeField] private AudioSource _audio;

    [SerializeField] private float _explosionForce = 500f;

    private int _damageObstacle = 20;

    public event Action<int> OnDamageHealthPlayer;

    public int Health => _player.Health;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Obstacle obstacle))
        {
            GameObject spawnedObject = Instantiate(_pfefabDestroy, obstacle.transform.position, Quaternion.identity, null);

            Rigidbody[] rigidbodies = spawnedObject.GetComponentsInChildren<Rigidbody>();

            foreach (Rigidbody rb in rigidbodies)
            {
                if (rb != null)
                {
                    Vector3 randomDirection = (rb.transform.position - obstacle.transform.position).normalized + UnityEngine.Random.insideUnitSphere;

                    rb.AddForce(randomDirection * _explosionForce);
                }
            }

            Destroy(obstacle.gameObject);

            _audio.Play();
            
            _player.Damage(_damageObstacle);
            OnDamageHealthPlayer?.Invoke(_damageObstacle);

            EnableMenuLoss();
        }
    }

    private void EnableMenuLoss()
    {
        if (_player.Health <= 0)
            _lossView.Show();
    }
}