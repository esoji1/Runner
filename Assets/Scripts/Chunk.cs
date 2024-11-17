using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private Transform _begin;
    [SerializeField] private Transform _and;

    public Transform Begin => _begin;
    public Transform And => _and;
}