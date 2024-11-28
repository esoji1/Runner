using UnityEngine;

public class DistanceTraveled : MonoBehaviour
{
    [SerializeField] private float _distance;
    private StateMachineData _data;

    private bool _isRun = true;

    public bool IsRun => _isRun;
    public int Distance => (int)_distance;

    private void Update()
    {
        if (_isRun == true)
            _distance += _data.SpeedSlap * Time.deltaTime;
    }

    public void Initialize(StateMachineData data)
    {
        _data = data;
    }

    public void StartDistance() => _isRun = true;
    public void StopDistance() => _isRun = false;
}