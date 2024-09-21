using UnityEngine;

public class ObstacleDetection : MonoBehaviour
{
    [SerializeField] private GameObject _image;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Obstacle obstacle))
        {
            Time.timeScale = 0;
            _image.SetActive(true);
        }
    }
}
