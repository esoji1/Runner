using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : ISpawners
{
    private GameObject _obstaclePrefab;
    private Transform[] _spawnPoints;
    private List<GameObject> spawnedObstacles;

    private float _timer = 0f;
    private float _spawnInterval = 0.7f;
    private int _obstaclesToExpulsion = 20;

    public ObstacleSpawner(Transform[] spawnPoints, GameObject obstaclePrefab)
    {
        _spawnPoints = spawnPoints;
        _obstaclePrefab = obstaclePrefab;

        spawnedObstacles = new List<GameObject>();
    }

    public void Spawner()
    {
        _timer += Time.deltaTime;

        if (_timer > _spawnInterval)
        {
            int randomIndex = Random.Range(0, _spawnPoints.Length);
            GameObject obstacle = Object.Instantiate(_obstaclePrefab, _spawnPoints[randomIndex].position, _spawnPoints[randomIndex].rotation);

            spawnedObstacles.Add(obstacle);
            _timer = 0;
        }
    }

    public void RemoveObjects()
    {
        if (spawnedObstacles.Count >= _obstaclesToExpulsion)
        {
            Object.Destroy(spawnedObstacles[0].gameObject);
            spawnedObstacles.RemoveAt(0);
        }
    }
}
