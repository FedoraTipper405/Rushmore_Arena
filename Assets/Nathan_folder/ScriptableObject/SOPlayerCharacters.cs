using UnityEngine;

[CreateAssetMenu(fileName = "SOPlayerCharacters", menuName = "Scriptable Objects/SOPlayerCharacters")]
public class SOPlayerCharacters : ScriptableObject
{
    public float moveSpeed;
    public float attackDamage;
    public float attackSpeed;
    public float health;
    public float attackRange;
    public bool isRangedAttacker;
    public int projectileAmount;
    public float projectileSpeed;
    public float projectileSize;
    public float knockBack;
    public int penetration;
    public float spread;
    
}
