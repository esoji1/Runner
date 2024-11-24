using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    [SerializeField] private CanvasGroup _bodyAlphaGroup;
    [SerializeField] private RectTransform _body;
    [SerializeField] private Button _button;

    private Vector2 _targetBodyPositon;
    private Vector2 _startShift;

    private Sequence _animation;

    private void Awake()
    {
        _targetBodyPositon = _body.anchoredPosition;
        _startShift = new Vector2(_targetBodyPositon.x, -Screen.height / 2);
    }

    public void Show()
    {
        KillCurrentAnimationIfActive();

        _animation = DOTween.Sequence();

        _animation
            .Append(_bodyAlphaGroup.DOFade(1, 0.5f).From(0))
            .Join(_body.DOAnchorPos(_targetBodyPositon, 1f).From(_startShift))
            .Append(_button.transform.DOScale(0.4f, 0.5f).From(0).SetEase(Ease.OutBounce));
    }

    public void Hide(Action callback)
    {
        KillCurrentAnimationIfActive(); 

        _animation = DOTween.Sequence();

        _animation
            .Append(_bodyAlphaGroup.DOFade(0, 1f).From(1))
            .Join(_body.DOAnchorPos(_startShift, 1f).From(_targetBodyPositon))
            .OnComplete(() => callback?.Invoke());
    }

    public bool IsAnimation() => _animation != null && _animation.active;

    private void KillCurrentAnimationIfActive()
    {
        if (IsAnimation())
            _animation.Kill();
    }
}