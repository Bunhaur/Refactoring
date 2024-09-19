using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class AutoShooting : MonoBehaviour
{
    [SerializeField] private Enemy[] _targets;
    [SerializeField] private Enemy _firstTarget;
    [SerializeField] private Bullet _prefab;
    [SerializeField] private float _cooldown;

    private Coroutine _createBulletsWork;

    void Start()
    {
        _createBulletsWork = StartCoroutine(CreateBullets());
    }

    IEnumerator CreateBullets()
    {
        Bullet bullet;
        var timeout = new WaitForSeconds(_cooldown);

        transform.LookAt(_firstTarget.transform);

        while (true)
        {
            bullet = Instantiate(_prefab, transform.position, Quaternion.identity);
            bullet.TransferParametres(_targets);

            yield return timeout;
        }
    }
}