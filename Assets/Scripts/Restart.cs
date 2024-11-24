using System.Collections;
using System.Threading;
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
        _lossView.Hide(() => _lossView.gameObject.SetActive(false));

        StartCoroutine(RestartAfterDelay(1f));
    }

    private IEnumerator RestartAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
    }
}