using System;
using UnityEngine;

public class FallDetection : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private LossView _lossView;

    private float _losingPosition = -20f;
    private bool _hasFallen; 

    public event Action OnDed;

    private void Update()
    {
        DidThePlayerFall();
    }

    private void DidThePlayerFall()
    {
        if (_hasFallen == false && _player.Transform.position.y <= _losingPosition)
        {
            _hasFallen = true;
            _lossView.gameObject.SetActive(true);
            OnDed?.Invoke();
        }
    }
}