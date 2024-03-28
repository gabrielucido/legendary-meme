using UnityEngine;

public class PlayerManager : MonoBehaviour, ICharacter
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


    public void AttackPressed()
    {
        if (attackPressed)
        {
            Debug.Log("Attacking");
        }
    }

    public void AttackReleased()
    {
        
    }

    public void TakeDamage(int damage)
    {
        this.healthPoints -= damage;
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