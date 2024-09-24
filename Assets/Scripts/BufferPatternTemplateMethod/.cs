public class BuffIncreasesSpeedInStraightLine : GivesBuff, IAddSpeed
{
    private float _speed = 10f;
    public float Speed => throw new System.NotImplementedException();

    public float SpeedMovementHorizontal => throw new System.NotImplementedException();

    public void AddSpeed(float speed)
    { 
        _speed += speed; 
    }

    public void AddSpeedHorizonal(float speedMovementHorizontal)
    {
        throw new System.NotImplementedException();
    }

    public void Affect() => _player.AddSpeed(_speed);

    protected override void Affect(IBuffPicker buffPicker)
    {
    }
}
