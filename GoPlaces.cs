using UnityEngine;

public class GoPlaces : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _path;
    [SerializeField] private Transform[] _arrayPoints;

    private int _index;

    private void Start()
    {
        _arrayPoints = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
            _arrayPoints[i] = _path.GetChild(i).GetComponent<Transform>();
    }

    private void Update()
    {
        var nextPoint = _arrayPoints[_index];
        transform.position = Vector3.MoveTowards(transform.position, nextPoint.position, _speed * Time.deltaTime);

        if (transform.position == nextPoint.position)
            MoveNextPoint();
    }

    private Vector3 MoveNextPoint()
    {
        _index++;

        if (_index == _arrayPoints.Length)
            _index = 0;

        var thisPoint = _arrayPoints[_index].transform.position;
        transform.forward = thisPoint - transform.position;

        return thisPoint;
    }
}