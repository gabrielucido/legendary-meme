using System;
using Unity.VisualScripting;
using UnityEngine;


public class EnemyPatrolController : EnemyController
{
    public GameObject[] patrolPoints;

    [SerializeField] private int currentPatrolPointIndex;

    private void Update()
    {
        HandlePatrol();
    }

    private void HandlePatrol()
    {
        if (manager.enemyMode != EnemyMode.Patrol) return;
        if (patrolPoints.Length == 0)
        {
            manager.enemyMode = EnemyMode.Idle;
            return;
        }

        var distanceToPatrolPoint =
            Vector3.Distance(transform.position, patrolPoints[currentPatrolPointIndex].transform.position);

        if (distanceToPatrolPoint <= 2)
        {
            currentPatrolPointIndex++;
        }

        if (currentPatrolPointIndex >= patrolPoints.Length)
        {
            currentPatrolPointIndex = 0;
        }

        manager.positionTarget = patrolPoints[currentPatrolPointIndex].transform.position;
    }

    #region Validation

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (patrolPoints.Length <= 0)
        {
            Debug.LogError(
                "Please assign a Patrol Waypoint to the Enemy Patrol Controller in the Patrol Points List slot", this);
        }
    }
#endif

    #endregion
}