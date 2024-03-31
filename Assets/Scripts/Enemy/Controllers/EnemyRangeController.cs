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
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var trigger = other.gameObject?.GetComponentInParent<IPlayer>();
        if (trigger != null)
        {
            manager.positionTarget = other.gameObject.transform.position;
            manager.enemyMode = EnemyMode.Chase;
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