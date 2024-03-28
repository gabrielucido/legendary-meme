using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerAttackController : PlayerController
{
    private void Update()
    {
        HandleAttack();
    }

    private void HandleAttack()
    {
        Physics.Raycast(player.cameraFollowTarget.transform.position, player.cameraFollowTarget.transform.forward,
            out var hit, 100);
        if (hit.collider == null) return;
        Debug.Log("Hitted!");
        Debug.Log(hit.collider.name);
        hit.collider.GetComponent<IEnemy>()?.TakeDamage(player.data.attackDamage);
    }
}