using UnityEngine;

public class LossView : MonoBehaviour
{
    [SerializeField] private GameObject _imageloss;

    private void Update()
    {
        if (_imageloss.activeSelf)
            Time.timeScale = 0;
    }

    public void Show() => _imageloss.SetActive(true);
    public void Hide() => _imageloss.SetActive(false);
}