using TMPro;
using Zenject;
using UnityEngine;

namespace Assets.Scripts.TestScripts.ZenjectInstalletrsTest
{
    public class Greeter : ITickable
    {
        private TextMeshProUGUI _textPrefab;
        private Canvas _canvas;

        public Greeter(TextMeshProUGUI textPrefab, Canvas canvas)
        {
            _textPrefab = textPrefab;
            _canvas = canvas;
        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Object.Instantiate(_textPrefab, _canvas.transform);
            }
        }
    }
}