using UnityEngine;

public class Enemy : BaseCharacter
{
    [SerializeField] private PlayerChaser _playerChaser;
    [SerializeField] private PatrolArea _patrolArea;
    [SerializeField] private PlayerDetector _playerDetector;

    private void Update()
    {
        if (_playerDetector.Detected)
        {
            _playerChaser.Chase();
        }
        else
        {
            _patrolArea.Patrol();
        }
    }
}
