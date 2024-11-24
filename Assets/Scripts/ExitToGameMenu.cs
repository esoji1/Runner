using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitToGameMenu : MonoBehaviour
{
    [SerializeField] private Button _exit;
    [SerializeField] private LossView _lossView;

    private void OnEnable()
    {
        _exit.onClick.AddListener(Exit);
    }

    private void OnDisable()
    {
        _exit.onClick.RemoveListener(Exit);
    }

    private void Exit()
    {
        _lossView.Hide(() => _lossView.gameObject.SetActive(false));

        StartCoroutine(RestartAfterDelay(1f));
    }

    private IEnumerator RestartAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        SceneManager.LoadScene(0);
    }
}