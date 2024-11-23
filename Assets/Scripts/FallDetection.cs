using UnityEngine;

public class FallDetection : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private LossView _lossView;

    private float _losingPosition = -20f;

    private void Update()
    {
        DidThePlayerFall();
    }

    private void DidThePlayerFall()
    {
        if (_player.Transform.position.y <= _losingPosition)
            _lossView.ActiveMenuLoss();
    }
}