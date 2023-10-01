using System.Collections;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private static PlayerBehavior _playerPosition;
    public static PlayerBehavior GetPlayerPosition()
    {
        return _playerPosition;
    }

    [SerializeField] private Material[] _colors;

    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _bulletSpawnPoint;

    [SerializeField] private float _shootDelay;
    [SerializeField] private float _shootSpeed;

    private Renderer _body;

    private int _index;

    private void Awake()
    {
        ScoreManager._score = 0;
        _playerPosition = this;
        _body = GetComponent<Renderer>();
        ChangeColor();
        StartCoroutine(Shoot());
    }

    private void OnMouseDown()
    {
        ChangeColor();
    }

    public void Aim(Transform _enemy)
    {
        Vector3 _target = _enemy.position - transform.position;
        transform.rotation = Quaternion.LookRotation(_target);
    }

    private void ChangeColor()
    {
        _body.material = _colors[_index];
        _index++;
        if (_index >= _colors.Length) _index = 0;
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            GameObject _temp = Instantiate(_bullet, _bulletSpawnPoint.position, transform.rotation);

            Rigidbody _tempRb = _temp.GetComponent<Rigidbody>();
            _tempRb.AddRelativeForce(Vector3.forward * _shootSpeed, ForceMode.Impulse);

            Renderer _tempRenderer = _temp.GetComponent<Renderer>();
            _tempRenderer.material = _body.material;

            Destroy(_temp, 4);

            yield return new WaitForSeconds(_shootDelay);
        }
    }
}
