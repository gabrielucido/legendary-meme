using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour, IEnemy
{
    [Header("Required initialization slots")]
    public EnemyData data;

    [Header("Health")] public int healthPoints;

    public void TakeDamage(int damage)
    {
        Debug.Log("Damamage taken: " + damage.ToString());
        healthPoints -= damage;
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
    }
#endif

    #endregion
}