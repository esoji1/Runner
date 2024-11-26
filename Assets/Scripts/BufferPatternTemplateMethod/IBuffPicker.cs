using Assets.Scripts;
using System;

public interface IBuffPicker : IAudioEffect
{
    float Speed { get; }
    float SpeedMovementHorizontal { get; }
    void AddSpeed(float speed);
    void AddSpeedHorizonal(float speedMovementHorizontal);
    void AddHealth(int health);
}