using UnityEngine;
using UnityEngine.Events;

public class MedKitCollector : MonoBehaviour
{
    [SerializeField] private int _healthPoints = 1;

    public UnityAction<int> MedKitCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out MedKit medKit))
        {
            MedKitCollected?.Invoke(_healthPoints);
            Destroy(medKit.gameObject);
        }
    }
}
