using TMPro;
using UnityEngine;

public class DistatnceView : MonoBehaviour
{
    [SerializeField] private DistanceTraveled _distanceTraveled;
    [SerializeField] private TextMeshProUGUI _distanceText;

    private void Update()
    {
        _distanceText.text = _distanceTraveled.Distance.ToString();
    }
}
