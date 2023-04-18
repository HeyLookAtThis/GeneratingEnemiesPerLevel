using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InstantiationActivator : MonoBehaviour
{
    private int _pointsCounter;

    private void Start()
    {
        InstantiationPoint[] points = FindObjectsOfType<InstantiationPoint>();
        StartCoroutine(ActivatePoint(points));
    }

    private IEnumerator ActivatePoint(InstantiationPoint[] points)
    {
        float seconds = 2.0f;
        var waitForSeconds = new WaitForSeconds(seconds);

        foreach (var point in points)
        {
            point.CreateEnemy();
            _pointsCounter++;
            yield return waitForSeconds;
        }

        if (_pointsCounter == points.Length)
            yield break;
    }
}
