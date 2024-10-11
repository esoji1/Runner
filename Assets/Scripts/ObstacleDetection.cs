using System;
using UnityEngine;

public class ObstacleDetection : MonoBehaviour
{
    [SerializeField] private Player _player;  
    [SerializeField] private GameObject _image;
    [SerializeField] private GameObject _pfefabDestroy;

    [SerializeField] private float explosionForce = 500f;
    [SerializeField] private float explosionRadius = 5f;

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

                    rb.AddForce(randomDirection * explosionForce);
                }
            }

            Destroy(obstacle.gameObject);

            _player.Damage(_damageObstacle);
            OnDamageHealthPlayer?.Invoke(_damageObstacle);

            EnableMenuLoss();
        }
    }

    private void EnableMenuLoss()
    {
        if (_player.Health <= 0)
        {
            Time.timeScale = 0;
            _image.SetActive(true);
        }
    }
}
