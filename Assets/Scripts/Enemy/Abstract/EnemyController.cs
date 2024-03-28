using UnityEngine;

/// <summary>
/// Base class for all enemy controllers
/// </summary>
/// <remarks>
/// This automatically sets a reference to the main EnemyManager script to be used within a controller.
///  For example to access the enemy's data scriptable object, you can use manager.data inside any controller instance
/// </remarks>
public abstract class EnemyController : MonoBehaviour
{
    protected EnemyManager manager;

    protected virtual void Awake()
    {
        manager = GetComponentInParent<EnemyManager>();
    }
}