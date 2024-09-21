public interface IBuffPicker
{
    float Speed { get; }
    float SpeedMovementHorizontal { get; }
    void AddSpeed(float speed);
    void AddSpeedHorizonal(float speedMovementHorizontal);
}
