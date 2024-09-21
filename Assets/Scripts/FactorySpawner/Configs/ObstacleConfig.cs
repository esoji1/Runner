using Packages.Rider.Editor.UnitTesting;
using System;
using UnityEngine;

[Serializable]
public class ObstacleConfig 
{
    [SerializeField] private GameObject _obstaclePrefab;
    [SerializeField, Range(0, 10)] private float _spawnInterval = 0.7f;
    private float _timer = 0;

    public GameObject ObstaclePrefab => _obstaclePrefab;
    public float SpawnInterval => _spawnInterval;
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
