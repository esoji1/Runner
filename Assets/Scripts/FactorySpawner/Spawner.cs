using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Factory _factory;
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private Chunk _firstChunk;
    [SerializeField] private Transform[] _spawnPointsObstacle;
    [SerializeField] private Transform[] _spawnPointsBuffs;

    private List<Chunk> _spawnedChunked = new List<Chunk>();
    private List<GameObject> _spawnedObstacles = new List<GameObject>();
    private List<GameObject> _spawnedBuffs = new List<GameObject>();
   
    public void StartSpawn()
    {
        _factory.GetPlatfom(_playerPosition, _spawnedChunked);
        _factory.GetObstacle(_spawnPointsObstacle, _spawnedObstacles);
        _factory.GetBuffes(_spawnPointsBuffs, _spawnedBuffs);
    }

    private void Awake()
    {
        _spawnedChunked.Add(_firstChunk);
    }
}