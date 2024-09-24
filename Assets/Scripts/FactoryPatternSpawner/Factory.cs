using UnityEngine;

public class Factory
{
    public ISpawners CreatePlatforms(Player player, Chunk _chunkPrefabs, Chunk firstChunk) 
        => new PlatformSpawner(player, _chunkPrefabs, firstChunk);

    public ISpawners CreateObstacles(Transform[] spawnPointsObstacle, GameObject obstaclePrefab)
        => new ObstacleSpawner(spawnPointsObstacle, obstaclePrefab);

    public ISpawners CreateBuffs(GameObject[] bufPrefab, Transform[] pointsBuffers)
        => new BufferSpawner(bufPrefab, pointsBuffers);
}
