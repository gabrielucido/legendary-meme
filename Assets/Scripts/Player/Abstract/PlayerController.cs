using UnityEngine;

/// <summary>
/// Base class for all player controllers 
/// </summary>
/// <remarks>
/// This automatically sets a reference to the main PlayerManager script to be used within a controller.
///  For example to access the player's data scriptable object, you can use PlayerController.playerData
/// </remarks>
public abstract class PlayerController : MonoBehaviour
{
    protected PlayerManager manager;

    protected virtual void Awake()
    {
        manager = GetComponentInParent<PlayerManager>();
    }
}