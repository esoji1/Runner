using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;

public class Increase : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private float _sizeScalePlayer = 30f;
    private float _sizeScalePlayerSum = 10f;
    private float _animationPlaybackIncrease = 3f;
    private float _maxPlayerScale = 40f;
    private Tween _animation;

    public event Action OnDestroy;

    public void IncreaseSize(float size)
    {
        _sizeScalePlayerSum += size;

        if (_sizeScalePlayerSum <= _sizeScalePlayer)
            _player.localScale += new Vector3(size, size, size);

        if (_sizeScalePlayerSum > _sizeScalePlayer)
            BoomPlayer();
    }

    private void BoomPlayer()
    {
        _animation = transform
            .DOScale(_maxPlayerScale, _animationPlaybackIncrease)
            .SetEase(Ease.OutQuad);

        StartCoroutine(ExplosionDelay(_animationPlaybackIncrease));
    }

    private IEnumerator ExplosionDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        _animation.Kill();
        OnDestroy?.Invoke();
    }
}