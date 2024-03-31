using System;
using UnityEngine;

public class EnemyAttackController : EnemyController
{
    private float _attackCooldown;

    private void Update()
    {
        HandleAttackCooldown();
        HandleAttack();
    }

    private void HandleAttackCooldown()
    {
        if (_attackCooldown > 0)
        {
            _attackCooldown -= Time.deltaTime;
        }
        else
        {
            _attackCooldown = 0;
        }
    }

    private void HandleAttack()
    {
        if (_attackCooldown > 0) return;

        if (manager.enemyMode == EnemyMode.Attack)
        {
            ExecuteAttack();
        }
    }

    private void ExecuteAttack()
    {
        _attackCooldown = manager.data.attackCooldown;
        manager.enemyMode = EnemyMode.Chase;
        manager.player.GetComponent<IPlayer>()?.TakeDamage(manager.data.attackDamage);
    }
}