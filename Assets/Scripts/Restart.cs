using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    [SerializeField] private LossView _lossView;
    [SerializeField] private Button _buttonRestart;

    private void OnEnable()
    {
        _buttonRestart.onClick.AddListener(RestartsScene);
    }

    private void OnDisable()
    {
        _buttonRestart.onClick.RemoveListener(RestartsScene);
    }

    private void RestartsScene()
    {
        SceneManager.LoadScene(1);
        _lossView.Hide();
        Time.timeScale = 1.0f;
    }
}