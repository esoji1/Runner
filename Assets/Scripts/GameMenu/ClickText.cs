using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickText : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out Play play))
                {
                    SceneManager.LoadScene(1);
                }
                else if (hit.collider.TryGetComponent(out Settings settings))
                {
                }
            }
        }
    }
}