using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    private void Update()
    {
        _spawner.StartSpawn();
    }
}
