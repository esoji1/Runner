using UnityEngine;

public class CollisionFixation : MonoBehaviour
{
    [SerializeField] private GroundChecker _groundChecker;

    private float _positionPlayerY = 0.060f;

    private void Update()
    {
        if (transform.position.y < _positionPlayerY && _groundChecker.IsTouches)
        {
            transform.position = new Vector3(transform.position.x, _positionPlayerY, transform.position.z);
        }
    }
}