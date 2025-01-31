using UnityEngine;

[CreateAssetMenu(fileName = "SOUpgradeCards", menuName = "Scriptable Objects/SOUpgradeCards")]
public class SOUpgradeCards : ScriptableObject
{
    public string CardName;

    public float moveSpeedUpgrade;
    public float attackDamageUpgrade;
    public float attackSpeedUpgrade;
    public float healthUpgrade;
    public float attackRangeUpgrade;
    public bool isRangedAttackerUpgrade;
    public int projectileAmountUpgrade;
    public float projectileSpeedUpgrade;
    public float projectileSizeUpgrade;
    public float knockBackUpgrade;
    public int penetrationUpgrade;
    public float spread;
    public bool isUniqueCardOne;

}
