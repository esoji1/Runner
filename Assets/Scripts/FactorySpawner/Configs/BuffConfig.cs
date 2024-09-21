using System;
using UnityEngine;

[Serializable]
public class BuffConfig
{
    [SerializeField] private GameObject[] _bufPrefab;
    [SerializeField, Range(1, 10)] private float _spawnInterval = 5f;
    private float _timer = 5f;

    public GameObject[] BufPrefab => _bufPrefab;
    public float spawnInterval => _spawnInterval;
    public float Timer
    {
        get
        {
            return _timer;
        }
        set
        {
            if(value < 0)
                throw new ArgumentException(nameof(value));

            _timer = value;
        }
    }
}