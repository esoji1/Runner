using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickText : MonoBehaviour
{
    [SerializeField] private Play _play;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {   
                if (hit.collider.TryGetComponent(out Play play))
                {
                    OnSceneLoaded();

                    SceneManager.LoadScene(1);
                    Time.timeScale = 1.0f;
                }

                if (hit.collider.TryGetComponent(out Settings settings))
                {
                }

                if (hit.collider.TryGetComponent(out Exit exit))
                {
                    Application.Quit();
                }
            }
        }
    }

    private void OnSceneLoaded()
    {
        DOTween.KillAll();
    }
}