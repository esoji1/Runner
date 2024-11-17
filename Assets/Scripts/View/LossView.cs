using UnityEngine;

public class LossView : MonoBehaviour
{
    [SerializeField] private GameObject _imageloss;

    public GameObject Imageloss => _imageloss;


    private void Update()
    {
        if (_imageloss.activeSelf)
            Time.timeScale = 0;
    }

    public void ActiveMenuLoss() => _imageloss.SetActive(true);
}