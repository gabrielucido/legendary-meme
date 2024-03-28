using UnityEngine;

[CreateAssetMenu]
public class EnemyData : CharacterData
{
    [Header("Movement")] [Tooltip("The enemy's acceleration")]
    public float acceleration = 0;
    
    [Tooltip("The player's max speed")]
    public float maxVelocity = 0;
}