using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoint;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private GameObject _enemy;

    private int _point;
    private int _lastSpawnPoint;

    private void Start()
    {
        _lastSpawnPoint = _spawnPoint.Length;
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            do
            {
                _point = Random.Range(0, _spawnPoint.Length);
            } while (_point == _lastSpawnPoint);

            Instantiate(_enemy, _spawnPoint[_point].position, Quaternion.identity);
            _lastSpawnPoint = _point;
            yield return new WaitForSeconds(_spawnDelay);
        }
    }
}
