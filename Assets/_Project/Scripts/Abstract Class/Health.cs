using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int _max = 100;

    private int _current;

    public event Action<int> Changed;

    public int Current => _current;

    public int Max => _max;

    private void Awake()
    {
        _current = _max;
    }

    public void TakeDamage(int damage)
    {
        if (damage >= 0)
        {
            _current -= damage;
        }

        if (_current <= 0)
        {
            _current = 0;

            Die();
        }

        Changed?.Invoke(_current);
    }

    public void Heal(int healthPoints)
    {
        _current = Mathf.Min(_current + healthPoints, _max);

        Changed?.Invoke(_current);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
