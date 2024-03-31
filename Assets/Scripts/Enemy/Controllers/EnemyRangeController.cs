using System;
using UnityEngine;

public class EnemyRangeController : EnemyController
{
    private void OnTriggerStay(Collider other)
    {
        var trigger = other.gameObject?.GetComponentInParent<IPlayer>();
        if (trigger != null)
        {
            manager.positionTarget = other.gameObject.transform.position;
            var playerDistance = Vector3.Distance(transform.position, other.gameObject.transform.position);
            if (playerDistance < 2)
            {
                manager.enemyMode = EnemyMode.Attack;
            }
            else
            {
                manager.enemyMode = EnemyMode.Chase;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var trigger = other.gameObject?.GetComponentInParent<IPlayer>();
        if (trigger != null)
        {
            manager.positionTarget = other.gameObject.transform.position;
            manager.enemyMode = EnemyMode.Chase;
            manager.player = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var trigger = other.gameObject?.GetComponentInParent<IPlayer>();
        if (trigger != null)
        {
            manager.positionTarget = transform.position;
            manager.enemyMode = EnemyMode.Patrol;
        }
    }
}