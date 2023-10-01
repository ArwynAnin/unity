using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private MeshRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.TryGetComponent<EnemyBehavior>(out EnemyBehavior _temp);
        other.gameObject.TryGetComponent<MeshRenderer>(out MeshRenderer _tempRenderer);

        if (_tempRenderer.material.color == _renderer.material.color) _temp.Destroy();
        Destroy (this.gameObject, 0.1f);
    }
}
