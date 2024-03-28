using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovementController : EnemyController
{
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // HandleMovement();
        // HandleDirection();
        // HandleGravity();
        // HandleStop();
        // GroundChecker();
    }

}