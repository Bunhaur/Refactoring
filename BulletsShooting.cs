using System.Collections;
using UnityEngine;

public class BulletsShooting : MonoBehaviour
{
    [SerializeField] private float _waitShootingTime;
    [SerializeField] private float _speed;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _target;

    private Coroutine _shootWork;

    private void Start()
    {
        _shootWork = StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        Rigidbody rigidBody;
        Bullet bullet;
        Vector3 direction;
        var timeout = new WaitForSeconds(_waitShootingTime);

        while (enabled)
        {
            direction = (_target.position - transform.position).normalized;
            bullet = Instantiate(_bullet, transform.position + direction, Quaternion.identity);
            rigidBody = bullet.GetRigidBody();
            rigidBody.velocity = direction * _speed;

            bullet.transform.up = direction;

            yield return timeout;
        }
    }
}