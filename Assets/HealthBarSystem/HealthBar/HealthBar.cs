using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] protected Health CharacterHealth;

    private void OnEnable()
    {
        CharacterHealth.Changed += OnHealthChanged;
    }

    private void OnDisable()
    {
        CharacterHealth.Changed -= OnHealthChanged;
    }

    protected virtual void OnHealthChanged(int health) { }
}
