using System;
using System.Collections;
using UnityEngine;

public class CubeRespawner : MonoBehaviour
{
    [SerializeField] private float _respawnTime;
    private CubeSpawner _cubeSpawner;
    private WaitForSeconds _waitForSeconds;
    private Vector3 _spawnPoint;
    public static Action OnCubeRespawned;

    private IEnumerator RespawnCube()
    {
        yield return _waitForSeconds;
        transform.position = _spawnPoint;
        //gameObject.SetActive(true);
        OnCubeRespawned?.Invoke();
    }

    private void Respawn() => StartCoroutine(RespawnCube());

    private void OnEnable() => CubeMover.OnMoved += Respawn;

    private void OnDisable() => CubeMover.OnMoved -= Respawn;

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(_respawnTime);
        _cubeSpawner = FindObjectOfType<CubeSpawner>();
    }

    private void Start()
    {
        _spawnPoint = _cubeSpawner.SpawnPoint;
        OnCubeRespawned?.Invoke();
    }
}