using UnityEngine;

public abstract class GivesBuff : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IBuffPicker buffPicker))
        {
            PlaySoundEffect(buffPicker);
            
            Affect(buffPicker);
            
            Destroy(gameObject);
        }
    }

    protected abstract void Affect(IBuffPicker buffPicker);
    
    protected abstract void PlaySoundEffect(IBuffPicker audio);
}