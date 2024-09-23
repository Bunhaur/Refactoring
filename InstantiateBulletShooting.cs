using System.Collections;
using UnityEngine;

public class InstantiateBulletsShooting : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _target;
    [SerializeField] private float _waitShootingTime;

    private Coroutine _shootingWork;

    private void Start()
    {
        _shootingWork = StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        var timeout = new WaitForSeconds(_waitShootingTime);
        Vector3 direction;
        Bullet bullet;

        while (true)
        {
            direction = (_target.position - transform.position).normalized;
            bullet = Instantiate(_bullet, transform.position + direction, Quaternion.identity);

            bullet.GetComponent<Rigidbody>().transform.up = direction;
            bullet.GetComponent<Rigidbody>().velocity = direction * _speed;

            yield return timeout;
        }
    }
}