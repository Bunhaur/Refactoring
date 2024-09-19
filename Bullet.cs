using UnityEngine;

[RequireComponent(typeof(BulletMovement))]

public class Bullet : MonoBehaviour
{
    private BulletMovement _bulletMovement;

    private void Awake()
    {
        _bulletMovement = GetComponent<BulletMovement>();
    }

    public void TransferParametres(Enemy[] enemies)
    {
        _bulletMovement.SetEnemiesPoints(enemies);
    }
}