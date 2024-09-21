using System;
using UnityEngine;

[Serializable]
public class PlatromConfig 
{
    [SerializeField] private Chunk _chunkPrefabs;
    [SerializeField] private int _platformSpawnDistance = 480;

    public Chunk ChunkPrefabs => _chunkPrefabs;
    public int PlatformSpawnDistance => _platformSpawnDistance;
}
