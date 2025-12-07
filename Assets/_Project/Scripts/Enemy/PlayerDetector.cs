using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public bool Detected { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            Detected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            Detected = false;
        }
    }
}
