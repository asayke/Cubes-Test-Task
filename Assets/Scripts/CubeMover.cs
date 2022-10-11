using System;
using DG.Tweening;
using UnityEngine;

public class CubeMover : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private float _speed;
    private Vector3 _endPoint;
    public static Action OnMoved;

    private void Move() => transform.DOMove(_endPoint, _distance / _speed).SetEase(Ease.Linear).OnComplete(() =>
    {
        // gameObject.SetActive(false);
        transform.position = Vector3.up * 100f;
        OnMoved?.Invoke();
    });

    private void OnEnable() => CubeRespawner.OnCubeRespawned += Move;

    private void OnDisable() => CubeRespawner.OnCubeRespawned += Move;

    private void Start() =>
        _endPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z + _distance);
}