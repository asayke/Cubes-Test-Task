using System;
using System.Collections;
using UnityEngine;

public class CubeRespawner : MonoBehaviour
{
    [SerializeField] private float _respawnTime;
    private CubeSpawner _cubeSpawner;
    private CubeMover _cubeMover;
    private WaitForSeconds _waitForSeconds;
    private Vector3 _spawnPoint;
    public static Action OnCubeRespawned;

    private void InitializeCube() => _cubeMover = FindObjectOfType<CubeMover>();

    private IEnumerator RespawnCube()
    {
        yield return _waitForSeconds;
        _cubeMover.transform.position = _spawnPoint;
        OnCubeRespawned?.Invoke();
    }

    private void Respawn() => StartCoroutine(RespawnCube());

    private void OnEnable()
    {
        CubeSpawner.OnSpawned += InitializeCube;
        CubeMover.OnMoved += Respawn;
    }

    private void OnDisable()
    {
        CubeSpawner.OnSpawned -= InitializeCube;
        CubeMover.OnMoved -= Respawn;
    }

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(_respawnTime);
        _cubeSpawner = FindObjectOfType<CubeSpawner>();
    }

    private void Start() => _spawnPoint = _cubeSpawner.SpawnPoint;
}