using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    [SerializeField] private GameObject _image;

    public void RestartsScene()
    {
        SceneManager.LoadScene(0);
        _image.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
