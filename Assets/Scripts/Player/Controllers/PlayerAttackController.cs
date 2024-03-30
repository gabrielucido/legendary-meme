using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerAttackController : PlayerController
{
    private bool _attacking;
    private float _cooldownTimer;

    private void Update()
    {
        HandleCooldownTimer();
        HandleAttack();
    }

    private void HandleCooldownTimer()
    {
        if (_cooldownTimer > 0)
        {
            _cooldownTimer -= Time.deltaTime;
        }
        else
        {
            _cooldownTimer = 0;
        }
    }

    public void HandleAttack()
    {
        if (_cooldownTimer > 0) return;
        if (!manager.attackPressed) return;

        _cooldownTimer = manager.data.attackCooldown;
        ExecuteAttack();
    }

    private void ExecuteAttack()
    {
        Physics.Raycast(manager.cameraFollowTarget.transform.position, manager.cameraFollowTarget.transform.forward,
            out var hit, 100);
        if (hit.collider == null) return;
        hit.collider.GetComponent<IEnemy>()?.TakeDamage(manager.data.attackDamage);
    }
}