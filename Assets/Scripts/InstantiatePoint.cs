using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]

public class InstantiatePoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    private int _enemiesCount = 3;
    private Transform _transform;
    private bool _isFree;

    private void Start()
    {
        _transform = GetComponent<Transform>();

        StartCoroutine(CreateEnemy());
    }

    private IEnumerator CreateEnemy()
    {
        Func<bool> func = IsPointBusy;
        var WaitWhile = new WaitUntil(func);
        Vector3 position = _transform.position;
        position.y *= 2;

        for (int i = 0; i < _enemiesCount; i++)
        {
            Enemy newEnemy = Instantiate(_enemy, position, Quaternion.identity);      

            yield return WaitWhile;

            if (i == _enemiesCount)
                yield break;
        }
    }

    private bool IsPointBusy()
    {
        return _isFree;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Enemy>(out Enemy enemy))
            _isFree = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent<Enemy>(out Enemy enemy))
            _isFree = true;
    }
}
