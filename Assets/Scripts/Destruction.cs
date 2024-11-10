using UnityEngine;

public class Destruction : MonoBehaviour
{
    [SerializeField] private GameObject _pfefab1;
    [SerializeField] private GameObject _pfefab2;

    [SerializeField] private float explosionForce = 500f; 
    [SerializeField] private float explosionRadius = 5f; 

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            GameObject spawnedObject = Instantiate(_pfefab1, _pfefab2.transform.position, Quaternion.identity);

            Rigidbody[] rigidbodies = spawnedObject.GetComponentsInChildren<Rigidbody>();

            foreach (Rigidbody rb in rigidbodies)
            {
                if (rb != null)
                {
                    Vector3 randomDirection = (rb.transform.position - _pfefab2.transform.position).normalized + Random.insideUnitSphere;

                    rb.AddForce(randomDirection * explosionForce, ForceMode.Impulse);
                }
            }

            Destroy(_pfefab2);
        }
    }
}