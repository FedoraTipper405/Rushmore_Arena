using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class MBUpgradeManager : MonoBehaviour
{
    [SerializeField] List<GameObject> upgradeCardList = new List<GameObject>();
    public List<SOUpgradeCards> upgradeSOList = new List<SOUpgradeCards>();
    
    [SerializeField] MBBasePlayerController[] presidentControllers = new MBBasePlayerController[4];
    private MBBasePlayerController selectedPresident;

    private GameObject UpgradeSlotOne;
    private GameObject UpgradeSlotTwo;
    private GameObject UpgradeSlotThree;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RandomizeThreeUpgrades();
        RandomizeThreeUpgrades();
        RandomizeThreeUpgrades();
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
    public void RandomizeThreeUpgrades()
    {
        if (UpgradeSlotOne != null)
        {
            UpgradeSlotOne = null;
        }
        if (UpgradeSlotTwo != null)
        {
            UpgradeSlotTwo = null;
        }
        if (UpgradeSlotThree != null)
        {
            UpgradeSlotThree = null;
        }
        int newSlotOne = Random.Range(0, upgradeCardList.Count);
        int newSlotTwo = Random.Range(0, upgradeCardList.Count);
        int newSlotThree = Random.Range(0, upgradeCardList.Count);

        UpgradeSlotOne = upgradeCardList[newSlotOne];
        UpgradeSlotTwo = upgradeCardList[newSlotTwo];
        UpgradeSlotThree = upgradeCardList[newSlotThree];
        Debug.Log(UpgradeSlotOne.GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName);
        Debug.Log(UpgradeSlotTwo.GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName);
        Debug.Log(UpgradeSlotThree.GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName);
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
