using UnityEngine;

[CreateAssetMenu(fileName = "SOBossStats", menuName = "Kyles SOs/SOBossStats")]
public class SOBossStats : ScriptableObject
{
    [SerializeField] public float BossMaxHealth;
    [SerializeField] public float BossDamage;
    [SerializeField] public float ArrowDamage;
    [SerializeField] public float ArrowSpeed;
    [SerializeField] public GameObject ArrowPrefab;
}
