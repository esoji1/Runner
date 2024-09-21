using System;
using UnityEngine;

public class StateMachineData : MonoBehaviour
{
    public float ZVelocity;
    public float YVelocity;

    private float _speed = 30;
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

    public float Speed
    {
        get => _speed;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(_speed));
        
            _speed = value;
        }
    }
}
