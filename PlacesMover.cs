using UnityEngine;

public class PlacesMover : MonoBehaviour
{
    [SerializeField] private Transform _way;

    private Vector3 _newPosition;
    private Transform[] _points;
    private Transform _point;
    private float _speed;
    private int _index;

    private void Start()
    {
        FillPoints();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _point = _points[_index];
        transform.position = Vector3.MoveTowards(transform.position, _point.position, _speed * Time.deltaTime);

        if (transform.position == _point.position)
            SetNextPoint();
    }

    private void FillPoints()
    {
        _points = new Transform[_way.childCount];

        for (int i = 0; i < _points.Length; i++)
            _points[i] = _way.GetChild(i);
    }

    private void SetNextPoint()
    {
        _index = ++_index % _points.Length;

        _newPosition = _points[_index].transform.position;
        transform.forward = _newPosition - transform.position;
    }
}