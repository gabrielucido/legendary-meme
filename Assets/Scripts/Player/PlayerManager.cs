using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IPlayer
{
    public PlayerData data;
    public GameObject cameraFollowTarget;
    public Vector2 moveDirection = Vector3.zero;
    public float rotationY;
    public Vector2 aimDirection = Vector3.zero;
    public bool attackPressed;
    public int healthPoints;

    void Start()
    {
        healthPoints = data.maxHealthPoints;
    }

    private void Update()
    {
        HandleDeathCondition();
    }


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