using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class HealthDrainAbility : MonoBehaviour
{
    [SerializeField] private AbilityAura _abilityAura;
    [SerializeField] private LayerMask _enemyLayerMask;
    [SerializeField] private int _damage = 1;

    private readonly float _duration = 6;

    private Coroutine _drainCoroutine;
    private int _healPoints;
    private bool _canDrain = true;

    private Health _playerHealth;

    private void Awake()
    {
        _playerHealth = GetComponent<Health>();

        _healPoints = _damage;
    }

    public void TryDrain()
    {
        if (_canDrain)
        {
            IDamageable enemy = FindEnemy();

            StartDrainCoroutine(enemy);
        }
    }

    private IDamageable FindEnemy()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, _abilityAura.Radius, _enemyLayerMask);

        foreach (Collider2D collider in hitColliders)
        {
            if (collider.gameObject.TryGetComponent(out IDamageable iDamageable))
            {
                return iDamageable;
            }
        }

        return null;
    }

    private IEnumerator Drain(IDamageable iDamageable)
    {
        if (iDamageable != null)
        {
            iDamageable.TakeDamage(_damage);
            _playerHealth.Heal(_healPoints);
        }

        _abilityAura.StartTransparencyCoroutine(_duration);

        _canDrain = false;

        yield return new WaitForSeconds(_duration);

        _canDrain = true;
    }

    private void StartDrainCoroutine(IDamageable iDamageable)
    {
        if (_drainCoroutine != null)
        {
            StopCoroutine(_drainCoroutine);
        }

        _drainCoroutine = StartCoroutine(Drain(iDamageable));
    }
}
