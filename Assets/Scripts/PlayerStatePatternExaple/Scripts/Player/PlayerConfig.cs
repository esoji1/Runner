using UnityEngine;

[CreateAssetMenu(menuName = "Configs/PlayerConfig", fileName = "PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    [field: SerializeField] public AirBornStateConfig AirBornStateConfig { get; private set; }
}
