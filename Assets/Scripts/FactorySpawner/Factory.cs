using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Factory", menuName = "Factory/FactoryObjects")]
public class Factory : ScriptableObject
{
    [SerializeField] private PlatromConfig _platromConfig;
    [SerializeField] private ObstacleConfig _obstacleConfig;
    [SerializeField] private BuffConfig _buffConfig;

    public void GetPlatfom(Transform player, List<Chunk> spawnedChunked)
    {
        if (player.position.x > spawnedChunked[spawnedChunked.Count - 1].And.position.x - _platromConfig.PlatformSpawnDistance)
        {
            int numberPlatformsPassed = 10;

            Chunk newChunk = Instantiate(_platromConfig.ChunkPrefabs);
            newChunk.transform.position = spawnedChunked[spawnedChunked.Count - 1].And.position - newChunk.Begin.localPosition;

            spawnedChunked.Add(newChunk);

            if (spawnedChunked.Count >= numberPlatformsPassed)
            {
                Destroy(spawnedChunked[0].gameObject);
                spawnedChunked.RemoveAt(0);
            }
        }
    }

    public void GetObstacle(Transform[] spawnPoints, List<GameObject> spawnedObstacles)
    {
        int obstaclesToExpulsion = 20;

        _obstacleConfig.Timer += Time.deltaTime;

        if (_obstacleConfig.Timer > _obstacleConfig.SpawnInterval)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            GameObject obstacle = Instantiate(_obstacleConfig.ObstaclePrefab, spawnPoints[randomIndex].position, spawnPoints[randomIndex].rotation);

            spawnedObstacles.Add(obstacle);
            _obstacleConfig.Timer = 0;
        }

        if (spawnedObstacles.Count >= obstaclesToExpulsion)
        {
            Destroy(spawnedObstacles[0].gameObject);
            spawnedObstacles.RemoveAt(0);
        }
    }

    public void GetBuffes(Transform[] points, List<GameObject> spawnedBuffs)
    {
        int numberBuffsPassed = 4;

        int randomIndex = Random.Range(0, points.Length);
        int randomIndexBufPrefab = Random.Range(0, 2);
        _buffConfig.Timer += Time.deltaTime;

        if (_buffConfig.Timer > _buffConfig.spawnInterval)
        {
            GameObject obstacle = Instantiate(_buffConfig.BufPrefab[randomIndexBufPrefab], points[randomIndex].position, points[randomIndex].rotation);
           
            spawnedBuffs.Add(obstacle);
            _buffConfig.Timer = 0;
        }

        if (spawnedBuffs.Count >= numberBuffsPassed)
        {
            Destroy(spawnedBuffs[0].gameObject);
            spawnedBuffs.RemoveAt(0);
        }
    }
}
