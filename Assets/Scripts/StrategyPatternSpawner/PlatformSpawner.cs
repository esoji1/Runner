using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : ISpawners
{
    private Player _player;
    private List<Chunk> _spawnedChunked;
    private Chunk _chunkPrefabs;

    private int _platformSpawnDistance = 480;
    private int _numberPlatformsPassed = 10;

    public PlatformSpawner(Player player, Chunk chunkPrefabs, Chunk firstChunk)
    {
        _player = player;
        _chunkPrefabs = chunkPrefabs;
        _spawnedChunked = new List<Chunk>();

        _spawnedChunked.Add(firstChunk);
    }

    public void Spawner()
    {
        if (_player.Transform.position.x > _spawnedChunked[_spawnedChunked.Count - 1].And.position.x - _platformSpawnDistance)
        {
            Chunk newChunk = Object.Instantiate(_chunkPrefabs);
            newChunk.transform.position = _spawnedChunked[_spawnedChunked.Count - 1].And.position - newChunk.Begin.localPosition;

            _spawnedChunked.Add(newChunk);
        }
    }

    public void RemoveObjects()
    {
        if (_spawnedChunked.Count >= _numberPlatformsPassed)
        {
            Object.Destroy(_spawnedChunked[0].gameObject);
            _spawnedChunked.RemoveAt(0);
        }
    }
}
