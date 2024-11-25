using UnityEngine;

public class ClickEnlarge : MonoBehaviour
{
    private float _sizeScalePlayer = 10f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if(hit.collider.gameObject.TryGetComponent(out Increase increase))
                {
                    increase.IncreaseSize(_sizeScalePlayer);
                }
            }
        }
    }
}