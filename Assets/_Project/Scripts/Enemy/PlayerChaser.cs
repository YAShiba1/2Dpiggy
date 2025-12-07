using UnityEngine;

public class PlayerChaser : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private EnemyMover _enemyMover;

    public void Chase()
    {
        _enemyMover.MoveHorizontallyTowards(_player);
    }
}
