using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class DetectionRing : MonoBehaviour
{
    [SerializeField] private PlayerBehavior _player;
    [SerializeField] private float _detectionRange;

    [SerializeField] private int _lines;
    [SerializeField] private float _radius;

    private LineRenderer _circle;
    private Transform _target;
    public static float _minDistance;

    private void Awake()
    {
        _circle = GetComponent<LineRenderer>();
        _minDistance = _detectionRange;
        DrawDetectionCircle();
    }

    private void Update()
    {
        DetectClosestEnemy();
    }

    private void DetectClosestEnemy()
    {
        foreach (EnemyBehavior _enemy in EnemyBehavior.GetEnemyList())
        {
            float _currentDistance = Vector3.Distance(transform.position, _enemy.transform.position);
            _minDistance = _minDistance > _currentDistance ? _currentDistance : _minDistance;
            if (_currentDistance > _detectionRange) return;
            if (_currentDistance == _minDistance)
            _target = _enemy.transform;

            if (_target == null) return;
            _player.Aim(_target);
        }
    }

    private void DrawDetectionCircle()
    {
        _circle.positionCount = _lines;

        for(int _index = 0; _index < _lines; _index++)
        {
            float _progress = (float) _index / _lines;
            float _angle = _progress* 2 * Mathf.PI;

            float x = Mathf.Cos(_angle) * _radius;
            float y = Mathf.Sin(_angle) * _radius;

            Vector3 _position = new Vector3(x, y, 0);

            _circle.SetPosition(_index, _position);
        }
    }
}
