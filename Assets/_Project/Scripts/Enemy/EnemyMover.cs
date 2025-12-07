using UnityEngine;

[RequireComponent(typeof(Flipper))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Flipper _flipper;

    private void Awake()
    {
        _flipper = GetComponent<Flipper>();
    }

    public void MoveHorizontallyTowards(Transform target)
    {
        Vector2 horizontalTarget = new(target.position.x, transform.position.y);

        transform.position = Vector2.MoveTowards(transform.position, horizontalTarget, _speed * Time.deltaTime);

        LookAtTarget(target);
    }

    private void LookAtTarget(Transform target)
    {
        if (target.position.x > transform.position.x && !_flipper.IsFacingRight)
        {
            _flipper.Flip();
        }
        else if (target.position.x < transform.position.x && _flipper.IsFacingRight)
        {
            _flipper.Flip();
        }
    }
}
