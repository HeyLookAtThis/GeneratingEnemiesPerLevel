using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private static int _pointsCount = 5;
    [SerializeField] private InstantiationPoint[] _points = new InstantiationPoint[_pointsCount];

    private void Start()
    {
        StartCoroutine(ActivatePoint(_points));
    }

    private IEnumerator ActivatePoint(InstantiationPoint[] points)
    {
        float seconds = 2.0f;
        var waitForSeconds = new WaitForSeconds(seconds);
        int pointsCounter = 0;

        foreach (var point in points)
        {
            point.CreateEnemy();
            pointsCounter++;
            yield return waitForSeconds;
        }

        if (pointsCounter == points.Length)
            yield break;
    }
}
