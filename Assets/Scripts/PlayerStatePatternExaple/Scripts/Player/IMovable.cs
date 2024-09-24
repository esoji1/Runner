using UnityEngine;

public interface IMovable
{
    float Speed { get; }
    float SpeedMovementHorizontal { get; }
    Transform Transform { get; }
}
