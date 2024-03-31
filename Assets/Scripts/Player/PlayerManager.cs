using UnityEngine;

public class PlayerManager : MonoBehaviour, IPlayer
{
    [Header("Required slots")]
    public PlayerData data;
    public GameObject cameraFollowTarget;
    

    [Header("Movement")]
    public Vector2 moveDirection = Vector3.zero;
    public float rotationY;
    
    [Header("Aim")] 
    public Vector2 aimDirection = Vector3.zero;
    
    [Header("Attacking")]
    public bool attackPressed;
    
    [Header("Health")] public int healthPoints;

    public void TakeDamage(int damage)
    {
        healthPoints -= damage;
    }

    public void HandleDeathCondition()
    {
        if (healthPoints <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        healthPoints = data.maxHealthPoints;
    }

    #region Validation

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (data == null)
        {
            Debug.LogError("Please assign a Player Data asset to the Player Manager data slot", this);
        }
        
        if (cameraFollowTarget == null)
        {
            Debug.LogError("Please assign a look target to the Player Manager look target slot", this);
        }
    }
#endif

    #endregion
}