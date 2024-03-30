using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementController : PlayerController
{
    private Rigidbody _rb;

    [SerializeField] private float _gravityVelocity = 9.81f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        HandleMovement();
        HandleDirection();
        HandleGravity();
        HandleStop();
        // GroundChecker();
    }

    private void HandleMovement()
    {
        _rb.AddForce(
            transform.TransformDirection(new Vector3(manager.moveDirection.x * manager.data.acceleration * Time.deltaTime,
                0,
                manager.moveDirection.y * manager.data.acceleration * Time.deltaTime)),
            ForceMode.VelocityChange);
        _rb.velocity = Vector3.ClampMagnitude(_rb.velocity, manager.data.maxVelocity);
    }

    private void HandleStop()
    {
        if (manager.moveDirection == Vector2.zero)
        {
            _rb.velocity /= 1.05f;
        }
    }

    private void HandleDirection()
    {
        transform.rotation = Quaternion.Euler(0f, manager.rotationY, 0f);
    }

    private void HandleGravity()
    {
        _rb.AddForce(new Vector3(0, -_gravityVelocity, 0), ForceMode.Force);
    }

    // private void GroundChecker()
    // {
    //     if (Physics.Raycast(transform.position, Vector3.down, out var hit, 1.1f))
    //     {
    //         if (hit.transform)
    //         {
    //             _rb.velocity = new Vector3(_rb.velocity.x, 0, _rb.velocity.z);
    //         }
    //     }
    //     else
    //     {
    //         _rb.velocity = new Vector3(_rb.velocity.x, -_gravityVelocity, _rb.velocity.z);
    //     }
    // }

    // private void GetSlopeAngle()
    // {
    //     if (Physics.Raycast(transform.position, Vector3.down, out var hit, 1.1f))
    //     {
    //         if (hit.transform.CompareTag("Ground"))
    //         {
    //             Debug.Log(Vector3.Angle(hit.normal, Vector3.up));
    //         }
    //     }
    // }
}