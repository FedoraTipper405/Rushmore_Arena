using UnityEngine;

[CreateAssetMenu(fileName = "SOUpgradeCards", menuName = "Scriptable Objects/SOUpgradeCards")]
public class SOUpgradeCards : ScriptableObject
{
    public float moveSpeedUpgrade;
    public float attackDamageUpgrade;
    public float attackSpeedUpgrade;
    public int healthUpgrade;
    public float attackRangeUpgrade;
    public bool isRangedAttackerUpgrade;
    public int projectileAmountUpgrade;
    public int projectileSpeedUpgrade;
    public int projectileSizeUpgrade;
    public float knockBackUpgrade;
    public int penetrationUpgrade;

}
