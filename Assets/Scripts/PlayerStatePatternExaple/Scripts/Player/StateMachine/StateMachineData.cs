using System;

public class StateMachineData
{
    public float ZVelocity;
    public float YVelocity;

    private float _speedHorizontal = 30;
    private float _speedSlap = 30;
    private float _zInput;

    public float ZInput
    {
        get => _zInput;
        set
        {
            if (_zInput < -1 || _zInput > 1)
                throw new ArgumentOutOfRangeException(nameof(_zInput));

            _zInput = value;
        }
    }

    public float SpeedHorizontal
    {
        get => _speedHorizontal;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(_speedHorizontal));
        
            _speedHorizontal = value;
        }
    }

    public float SpeedSlap
    {
        get => _speedSlap;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(_speedSlap));

            _speedSlap = value;
        }
    }
}
