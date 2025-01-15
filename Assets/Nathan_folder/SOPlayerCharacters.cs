using UnityEngine;

[CreateAssetMenu(fileName = "SOPlayerCharacters", menuName = "Scriptable Objects/SOPlayerCharacters")]
public class SOPlayerCharacters : ScriptableObject
{
    public float moveSpeed;
    public float attackDamage;
    public float attackSpeed;
    public int health;
    public float attackRange;
    public bool isRangedAttacker;
    public int projectileAmount;
    public int projectileSpeed;
    public int projectileSize;
    public float knockBack;
    public int penetration;
    
}
