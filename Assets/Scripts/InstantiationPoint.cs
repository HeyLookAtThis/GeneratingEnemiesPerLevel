using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiationPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    public void CreateEnemy()
    {        
        float distanceFromCenter = 2.0f;
        float rightAngle = 90.0f;

        Vector3 position = transform.position;
        position.y *= distanceFromCenter;

        Quaternion rotation = Quaternion.Euler(0, rightAngle, 0);

        Enemy newEnemy = Instantiate(_enemy, position, rotation);
    }
}
