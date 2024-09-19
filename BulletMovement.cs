using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Enemy[] _enemyPoints;
    private Vector3 _currentPoint;
    private Enemy _enemyPoint;
    private int _index;

    public void Update()
    {
        Move();
    }

    public void SetEnemiesPoints(Enemy[] points)
    {
        _enemyPoints = points;
        _currentPoint = _enemyPoints[_index].transform.position;
        _enemyPoint = _enemyPoints[_index];
    }

    private void SetNextPoint()
    {
        _index++;

        if (_index == _enemyPoints.Length)
            _index = 0;

        _currentPoint = _enemyPoints[_index].transform.position;
        transform.forward = _currentPoint - transform.position;
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentPoint, _speed * Time.deltaTime);

        if (transform.position == _currentPoint)
            SetNextPoint();
    }
}