using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] private GameObject _pfefabDestroy;
    [SerializeField] private Increase _increase;
    [SerializeField] private GameObject _player;
    [SerializeField] private float _explosionForce = 500f;

    private void OnEnable()
    {
        _increase.OnDestroy += Explosion;
    }

    private void OnDisable()
    {
        _increase.OnDestroy -= Explosion;
    }

    private void Explosion()
    {
        GameObject spawnedObject = Instantiate(_pfefabDestroy, _player.transform.position, Quaternion.identity, null);

        Rigidbody[] rigidbodies = spawnedObject.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rb in rigidbodies)
        {
            if (rb != null)
            {
                Vector3 randomDirection = (rb.transform.position - _player.transform.position).normalized + UnityEngine.Random.insideUnitSphere;

                rb.AddForce(randomDirection * _explosionForce);
            }
        }

        Destroy(_player);
    }
}