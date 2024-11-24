using DG.Tweening;
using UnityEngine;

public class DotweenGameMenuTest : MonoBehaviour
{
    [SerializeField] private GameObject _cube;

    private Tween _animation;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //_cube.transform.DOMoveX(10, 1.5f).From(0).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
            _animation = _cube.transform
                .DORotate(new Vector3(0, 360, 0), 1.5f, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear)
                .SetLoops(-1);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            _animation.Kill();

            Destroy(_cube);
        }
    }
}