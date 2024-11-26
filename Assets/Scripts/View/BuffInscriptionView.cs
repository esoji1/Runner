using DG.Tweening;
using TMPro;

namespace Assets.Scripts
{
    public class BuffInscriptionView
    {
        private Tween _animation;

        public void ShowAnimation(TextMeshProUGUI textInfo)
        {
            textInfo.alpha = 0;

            _animation = textInfo
                .DOFade(1, 1f);
        }
    }
}