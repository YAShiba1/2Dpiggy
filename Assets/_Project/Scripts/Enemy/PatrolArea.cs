using UnityEngine;

public class PatrolArea : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private EnemyMover _enemyMover;

    private Transform[] _points;
    private float _targetReachedThreshold = 0.1f;
    private int _currentPoint;

    private void Awake()
    {
        InitializePatrolPoints();
    }

    public void Patrol()
    {
        Transform target = _points[_currentPoint];

        _enemyMover.MoveHorizontallyTowards(target);

        if (Utilities.IsNearTarget(transform, target, _targetReachedThreshold))
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }

    private void InitializePatrolPoints()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }
}
