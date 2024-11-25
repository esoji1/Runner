using DG.Tweening;
using TMPro;
using UnityEngine;

public class AnimationsHelpText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _helpText;

    private int _timeRemoveHelp = 5;
    private float _time;
    private bool _isCountTime = true;

    private Tween _animation;

    private void Start()
    {
        AnimationPlayZoomAndOut();
    }

    private void Update()
    {
        if (_isCountTime)
        {
            _time += Time.deltaTime;

            if (_time >= _timeRemoveHelp)
            {
                if (_helpText != null)
                {
                    _animation.Kill();  
                    Destroy(_helpText.gameObject); 
                }

                _isCountTime = false;
            }
        }
    }

    private void AnimationPlayZoomAndOut()
    {
        _animation = _helpText.rectTransform
            .DOScale(new Vector3(5f, 5f, 5f), 0.5f)
            .SetLoops(-1, LoopType.Yoyo);
    }
}