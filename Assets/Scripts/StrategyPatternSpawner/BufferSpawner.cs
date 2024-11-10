using System.Collections.Generic;
using UnityEngine;

public class BufferSpawner : ISpawners
{
    private List<GameObject> _spawnedBuffs;
    private GameObject[] _bufPrefab;
    private Transform[] _points;

    private int _numberBuffsPassed = 4;
    private float _timer = 0;
    private float _spawnInterval = 5f;

    public BufferSpawner(GameObject[] bufPrefab, Transform[] points)
    {
        _bufPrefab = bufPrefab;
        _points = points;

        _spawnedBuffs = new List<GameObject>();
    }

    public void Spawner()
    {
        int randomIndex = Random.Range(0, _points.Length);
        int randomIndexBufPrefab = Random.Range(0, 3);
        _timer += Time.deltaTime;

        if (_timer > _spawnInterval)
        {
            GameObject obstacle = Object.Instantiate(_bufPrefab[randomIndexBufPrefab], _points[randomIndex].position, _points[randomIndex].rotation);

            _spawnedBuffs.Add(obstacle);
            _timer = 0;
        }
    }

    public void RemoveObjects()
    {
        if (_spawnedBuffs.Count >= _numberBuffsPassed)
        {
            Object.Destroy(_spawnedBuffs[0].gameObject);
            _spawnedBuffs.RemoveAt(0);
        }
    }
}
