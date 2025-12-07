using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private int _groundContactCount = 0;

    public bool IsGrounded => _groundContactCount > 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Ground ground))
        {
            _groundContactCount++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Ground ground))
        {
            _groundContactCount--;
        }
    }
}
