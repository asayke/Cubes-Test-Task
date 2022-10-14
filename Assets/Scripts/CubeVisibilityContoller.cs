using UnityEngine;

public class CubeVisibilityContoller : MonoBehaviour
{
    private CubeMover _cubeMover;

    private void InitializeCube() => _cubeMover = FindObjectOfType<CubeMover>();

    private void DisableCube() => _cubeMover.gameObject.SetActive(false);

    private void EnableCube() => _cubeMover.gameObject.SetActive(true);

    private void OnEnable()
    {
        CubeSpawner.OnSpawned += InitializeCube;
        CubeMover.OnMoved += DisableCube;
        CubeRespawner.OnCubeRespawned += EnableCube;
    }

    private void OnDisable()
    {
        CubeSpawner.OnSpawned -= InitializeCube;
        CubeMover.OnMoved -= DisableCube;
        CubeRespawner.OnCubeRespawned -= EnableCube;
    }
}