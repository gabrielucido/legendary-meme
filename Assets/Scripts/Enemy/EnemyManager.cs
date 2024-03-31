using System;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour, IEnemy
{
    [Header("Required initialization slots")]
    public EnemyData data;

    public Vector3 positionTarget;
    public EnemyMode enemyMode = EnemyMode.Idle;

    [Header("Health")] public int healthPoints;

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
    }
#endif

    #endregion
}