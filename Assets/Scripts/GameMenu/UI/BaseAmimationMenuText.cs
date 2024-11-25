using DG.Tweening;
using TMPro;
using UnityEngine;

public abstract class BaseAmimationMenuText : MonoBehaviour
{
    protected abstract TextMeshProUGUI Text { get; }

    private Sequence _animation;

    public Sequence Animation => _animation;

    public void Show()
    {
        _animation.Kill();

        _animation = DOTween.Sequence();

        _animation
            .SetUpdate(true)
            .Append(Text.rectTransform.DOAnchorPosX(100, 1f).SetEase(Ease.Linear))
            .Join(Text.rectTransform.DOScale(2f, 1f).SetEase(Ease.Linear));
    }

    public void Hide()
    {
        _animation.Kill();

        _animation = DOTween.Sequence();

        _animation
            .SetUpdate(true)
            .Append(Text.rectTransform.DOAnchorPosX(9, 1f).SetEase(Ease.Linear))
            .Join(Text.rectTransform.DOScale(1.6f, 1f).SetEase(Ease.Linear));
    }
}