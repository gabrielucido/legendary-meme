using Unity;
using UnityEngine;

public abstract class CharacterData : ScriptableObject
{
    [Header("General")]
    [Tooltip("Player max health points")]
    public int maxHealthPoints = 100;

    [Header("Attack")]
    [Tooltip("Cooldown between attacks"), Range(.1f, 60)] 
    public float attackCooldown = 1;

    [Tooltip("Damage dealt by each attack")]
    public int attackDamage = 40;
}