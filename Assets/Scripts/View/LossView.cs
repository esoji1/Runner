using DG.Tweening;
using System;
using UnityEngine;

public class LossView : MonoBehaviour
{
    [SerializeField] private CanvasGroup _bodyAlphaGroup;
    [SerializeField] private RectTransform _body;
    [SerializeField] private ObstacleDetection _obstacleDetection;
    [SerializeField] private FallDetection _fallDetection;

    private Vector2 _targetBodyPositon;
    private Vector2 _startShift;

    private Sequence _animation;

    private void Awake()
    {
        _targetBodyPositon = _body.anchoredPosition;
        _startShift = new Vector2(_targetBodyPositon.x, -Screen.height / 2);
    }

    private void OnEnable()
    {
        _obstacleDetection.OnDed += StopTime;
        _fallDetection.OnDed += StopTime;
    }

    private void OnDisable()
    {
        _obstacleDetection.OnDed -= StopTime;
        _fallDetection.OnDed -= StopTime;
    }

    public void Show()
    {
        KillCurrentAnimationIfActive();

        _animation = DOTween.Sequence();

        _animation
            .SetUpdate(true)
            .Append(_bodyAlphaGroup.DOFade(1, 0.5f).From(0))
            .Join(_body.DOAnchorPos(_targetBodyPositon, 1f).From(_startShift));
    }

    public void Hide(Action callback)
    {
        KillCurrentAnimationIfActive();

        _animation = DOTween.Sequence();

        _animation
            .SetUpdate(true)
            .Append(_bodyAlphaGroup.DOFade(0, 1f).From(1))
            .Join(_body.DOAnchorPos(_startShift, 1f).From(_targetBodyPositon))
            .OnComplete(() => callback?.Invoke());
    }

    private void KillCurrentAnimationIfActive() 
        => _animation.Kill();

    private void StopTime()
    {
        Time.timeScale = 0;
        Show();
    }
}