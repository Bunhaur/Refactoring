using UnityEngine;

public class GoPlaces : MonoBehaviour
{
    [SerializeField] private Transform _allPlacesPoint;

    private Transform[] _points;
    private Transform _point;
    private Vector3 _newPosition;
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
            NextPlaceTakerLogic();
    }

    private void FillPoints()
    {
        _points = new Transform[_allPlacesPoint.childCount];

        for (int i = 0; i < _allPlacesPoint.childCount; i++)
            _points[i] = _allPlacesPoint.GetChild(i).GetComponent<Transform>();
    }

    private Vector3 NextPlaceTakerLogic()
    {
        _index = ++_index % _points.Length;

        _newPosition = _points[_index].transform.position;
        transform.forward = _newPosition - transform.position;

        return _newPosition;
    }
}