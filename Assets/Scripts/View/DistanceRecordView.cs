using TMPro;
using UnityEngine;

public class DistanceRecordView : MonoBehaviour
{
    [SerializeField] private DistanceTraveled _distanceTraveled;
    [SerializeField] private TextMeshProUGUI _recordText;

    private void Update()
    {
        _recordText.text = _distanceTraveled.Distance.ToString();
    }
}