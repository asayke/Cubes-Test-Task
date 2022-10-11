using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private Transform _spawnPoint;

    public Vector3 SpawnPoint => _spawnPoint.position;

    private void Start() => Instantiate(_cubePrefab, _spawnPoint.position, _cubePrefab.transform.rotation);
}