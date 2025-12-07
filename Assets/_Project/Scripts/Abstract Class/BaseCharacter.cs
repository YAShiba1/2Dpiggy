using UnityEngine;

public abstract class BaseCharacter : MonoBehaviour
{
    [SerializeField] protected Health Health;

    protected int Damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable iDamageable))
        {
            iDamageable.TakeDamage(Damage);
        }
    }
}
