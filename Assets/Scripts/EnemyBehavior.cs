using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public static List<EnemyBehavior> _enemyList = new List<EnemyBehavior>();
    public static List<EnemyBehavior> GetEnemyList()
    {
        return _enemyList;
    }

    [SerializeField] private Transform _player;
    [SerializeField] private float _speed;
    private Vector3 _targetOrientation;
    private Vector3 _lastOrientation;

    private void Awake()
    {
        _enemyList.Add(this);
        _lastOrientation = Vector3.one;
    }

    private void FixedUpdate()
    {
        Rotate();
        ApproachPlayer();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        Gameover();
    }

    private void Rotate()
    {
        if (_player.position == _lastOrientation) return;

        _targetOrientation = _player.position - transform.position;
        transform.rotation = Quaternion.LookRotation(_targetOrientation);
        _lastOrientation = _player.position;
    }

    private void ApproachPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, _player.position, _speed * Time.fixedDeltaTime);
    }

    public void Destroy()
    {
        DetectionRing._minDistance = 7.5f;
        _enemyList.Remove(this);
        Destroy(gameObject);
    }

    private void Gameover()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
