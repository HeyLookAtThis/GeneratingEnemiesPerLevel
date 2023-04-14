using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    private int _enemiesCount = 3;

    private List<Vector3> _spawnPositions = new List<Vector3>();

    private void Start()
    {
        InitiateSpawnPositions();
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        float seconds = 0.5f;
        var enumerator = new WaitForSeconds(seconds);


        for (int i=0; i<_spawnPositions.Count; i++)
        {
            StartCoroutine(CreateEnemy(_spawnPositions[i]));
            yield return enumerator;

            if (i == _spawnPositions.Count)
                yield break;
        }
    }

    private IEnumerator CreateEnemy(Vector3 position)
    {
        float seconds = 2.0f;
        var enumerator = new WaitForSeconds(seconds);

        for (int i = 0; i < _enemiesCount; i++)
        {
            var newEnemy = Instantiate(_enemy, position, Quaternion.identity);
            yield return enumerator;

            if (i == _enemiesCount)
                yield break;
        }
    }

    private void InitiateSpawnPositions()
    {
        float topPosition = 10.0f;
        float bottomPosition = 20.0f;
        float height = 3;

        Vector3 topLeftPoint = new Vector3(topPosition, height, topPosition);
        Vector3 topRightPoint = new Vector3(topPosition, height, bottomPosition);
        Vector3 bottomLeftPoint = new Vector3(bottomPosition, height, topPosition);
        Vector3 bottomRightPoint = new Vector3(bottomPosition, height, bottomPosition);

        _spawnPositions.Add(topLeftPoint);
        _spawnPositions.Add(topRightPoint);
        _spawnPositions.Add(bottomLeftPoint);
        _spawnPositions.Add(bottomRightPoint);
    }
}
