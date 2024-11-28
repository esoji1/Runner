using System.Collections.Generic;
using UnityEngine;

public class SpawnerConfigurator : MonoBehaviour
{
    private List<ISpawners> _spawners = new List<ISpawners>();

    public void SetSpawners(ISpawners spawners)
    {
        _spawners.Add(spawners);
    }

    public void Spawner()
    {
        foreach (ISpawners spawner in _spawners)
        {
            spawner.Spawner();
        }
    }

    public void RemoveObjects()
    {
        foreach (ISpawners spawner in _spawners)
        {
            spawner.RemoveObjects();
        }
    }
}