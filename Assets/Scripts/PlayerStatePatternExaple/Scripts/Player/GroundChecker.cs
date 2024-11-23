using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _ground;

    [SerializeField, Range(0.01f, 1)] private float _distanceToCheck;
    [SerializeField] private Transform[] _transformCube;

    public bool IsTouches { get; private set; }

    private void Update()
    {
        IsTouches = false;
        foreach (Transform point in _transformCube)
        {
            if (Physics.CheckSphere(point.position, _distanceToCheck, _ground))
            {
                IsTouches = true; 
                break; 
            }
        }
    }
}