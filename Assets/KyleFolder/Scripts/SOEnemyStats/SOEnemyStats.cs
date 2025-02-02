using UnityEngine;

[CreateAssetMenu(fileName = "SOEnemyStats", menuName = "Kyles SOs/SOEnemyStats")]
public class SOEnemyStats : ScriptableObject
{
    [SerializeField] public float EnemyMaxHealth;
    [SerializeField] public float EnemyDamage;
    [SerializeField] public float AttackTimer;
    [SerializeField] public float DetectTimer;
    [SerializeField] public float ArrowSpeed;
    [SerializeField] public GameObject ArrowPrefab;
}
