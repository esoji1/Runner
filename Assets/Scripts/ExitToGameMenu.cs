using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitToGameMenu : MonoBehaviour
{
    [SerializeField] private Button _exit;

    private void OnEnable()
    {
        _exit.onClick.AddListener(Exit);
    }

    private void OnDisable()
    {
        _exit.onClick.RemoveListener(Exit);
    }

    private void Exit() 
        => SceneManager.LoadScene(0);
}