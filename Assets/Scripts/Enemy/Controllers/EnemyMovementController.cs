using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMovementController : EnemyController
{
    private NavMeshAgent _nma;

    private void Start()
    {
        _nma = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (manager.enemyMode == EnemyMode.Idle) return;
        if (Vector3.Distance(manager.positionTarget, transform.position) > .5f)
        {
            MoveTo(manager.positionTarget);
        }
    }

    private void MoveTo(Vector3 target)
    {
        _nma.SetDestination(target);
    }
}