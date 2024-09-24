using UnityEngine;

public class ComponentInitializer : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Chunk _chunkPrefabs;
    [SerializeField] private Chunk _firstChunk;
    [SerializeField] private GameObject _obstaclePrefab;
    [SerializeField] private Transform[] _spawnPointsObstacle;
    [SerializeField] private GameObject[] _bufPrefab;
    [SerializeField] private Transform[] _pointsBuffers;
    [SerializeField] private SpawnerConfigurator _spawnerConfigurator;

    private Factory _factory;

    private void Awake()
    {
        _factory = new Factory();
    }

    private void Start()
    {
        _spawnerConfigurator.SetSpawners(_factory.CreatePlatforms(_player, _chunkPrefabs, _firstChunk));
        _spawnerConfigurator.SetSpawners(_factory.CreateObstacles(_spawnPointsObstacle, _obstaclePrefab));
        _spawnerConfigurator.SetSpawners(_factory.CreateBuffs(_bufPrefab, _pointsBuffers));
    }

    private void Update()
    {
        _spawnerConfigurator.Spawner();
        _spawnerConfigurator.RemoveObjects();
    }
}
