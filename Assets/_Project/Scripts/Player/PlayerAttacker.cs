using System.Collections;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private HealthDrainAbility _healthDrain;

    private readonly float _cooldown = 4;

    private Coroutine _attackWithCooldownJob;

    private KeyCode _attackButon = KeyCode.R;
    private bool _canAttack = true;

    private void Update()
    {
        if (Input.GetKeyDown(_attackButon) && _canAttack)
        {
            StartAttackCoroutine();

            _canAttack = false;
        }
    }

    private IEnumerator AttackWithCooldown()
    {
        _healthDrain.TryDrain();

        yield return new WaitForSeconds(_cooldown);

        _canAttack = true;
    }

    private void StartAttackCoroutine()
    {
        if(_attackWithCooldownJob != null )
        {
            StopCoroutine(AttackWithCooldown());
        }

        _attackWithCooldownJob = StartCoroutine(AttackWithCooldown());
    }
}
