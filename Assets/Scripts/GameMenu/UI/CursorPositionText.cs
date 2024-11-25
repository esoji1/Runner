using UnityEngine;

public class CursorPositionText : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;

    private BaseAmimationMenuText _currentAnimation;

    private void Update()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit) &&
            hit.transform.gameObject.TryGetComponent(out BaseAmimationMenuText animation))
        {
            if (_currentAnimation != animation)
            {
                _currentAnimation?.Hide();
                _currentAnimation = animation;
                _currentAnimation.Show();
            }
        }
        else
        {
            if (_currentAnimation != null)
            {
                _currentAnimation.Hide();
                _currentAnimation = null;
            }
        }
    }
}