using UnityEngine;

public abstract class GivesBuff : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out IBuffPicker buffPicker))
        {
            Affect(buffPicker);

            Destroy(gameObject);
        }
    }

    protected abstract void Affect(IBuffPicker buffPicker);
}
