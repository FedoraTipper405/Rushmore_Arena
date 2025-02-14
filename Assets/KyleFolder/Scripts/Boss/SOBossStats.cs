using UnityEngine;

[CreateAssetMenu(fileName = "SOBossStats", menuName = "Kyles SOs/SOBossStats")]
public class SOBossStats : ScriptableObject
{
    [SerializeField] public float BossMaxHealth;
    [SerializeField] public float BossMeleeDamage;
    [SerializeField] public float ArrowDamage;
    [SerializeField] public float ArrowSpeed;
    [SerializeField] public float MovementSpeed;
    [SerializeField] public float TimeUntilStateChange;
    [SerializeField] public float ChargeSpeed;
    [SerializeField] public float TimeUntilCharge;
    [SerializeField] public float DistanceCheck;
    [SerializeField] public float RadiusOfGroundSlam;
    [SerializeField] public int NumberOfArrowsSpiral;
    [SerializeField] public int NumberOfArrowsBurst;
    [SerializeField] public int ArrowBurstTimes;
    [SerializeField] public int ArrowSpiralTimes;
    [SerializeField] public float TimeUntilFireArrow;
    [SerializeField] public float CantReachPlayerTimer;
    [SerializeField] public int NumberOfCharges;
    [SerializeField] public GameObject ArrowPrefab;
}
