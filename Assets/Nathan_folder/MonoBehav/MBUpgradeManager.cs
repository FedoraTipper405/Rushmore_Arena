using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class MBUpgradeManager : MonoBehaviour
{
    [SerializeField] List<GameObject> upgradeCardList = new List<GameObject>();
    public List<SOUpgradeCards> upgradeSOList = new List<SOUpgradeCards>();
    
    [SerializeField] MBBasePlayerController[] presidentControllers = new MBBasePlayerController[4];
    private MBBasePlayerController selectedPresident;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void OnEnable()
    {
        for (int i = 0; i < presidentControllers.Length; i++)
        {
            if (presidentControllers[i].gameObject.activeSelf)
            {
                selectedPresident = presidentControllers[i];
            }
        }
        for(int i = 0;i < upgradeCardList.Count; i++)
        {
            upgradeSOList.Add(upgradeCardList[i].GetComponent<MBHoldUpgradeSO>().upgradeSO);
        }
    }
    public void UpgradeCharacter(SOUpgradeCards selectedUpgrade)
    {
        selectedPresident.moveSpeed += selectedUpgrade.moveSpeedUpgrade;
        selectedPresident.attackDamage += selectedUpgrade.attackDamageUpgrade;
        selectedPresident.attackSpeed += selectedUpgrade.attackSpeedUpgrade;
        selectedPresident.health += selectedUpgrade.healthUpgrade;
        selectedPresident.attackRange += selectedUpgrade.attackRangeUpgrade;
        selectedPresident.projectileAmount += selectedUpgrade.projectileAmountUpgrade;
        selectedPresident.projectileSpeed += selectedUpgrade.projectileSpeedUpgrade;
        selectedPresident.projectileSize += selectedUpgrade.projectileSizeUpgrade;
        selectedPresident.knockBack += selectedUpgrade.knockBackUpgrade;
        selectedPresident.penetration += selectedUpgrade.penetrationUpgrade;

        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
