using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class MBUpgradeManager : MonoBehaviour
{
    [SerializeField] List<GameObject> upgradeCardList = new List<GameObject>();
    public List<SOUpgradeCards> upgradeSOList = new List<SOUpgradeCards>();
    public int currentSelectedUpgrade = 0;

    
    [SerializeField] MBBasePlayerController[] presidentControllers = new MBBasePlayerController[4];
    private MBBasePlayerController selectedPresident;

    private GameObject UpgradeSlotOne;
    private GameObject UpgradeSlotTwo;
    private GameObject UpgradeSlotThree;

    private GameObject UpgradeUIElementOne;
    private GameObject UpgradeUIElementTwo;
    private GameObject UpgradeUIElementThree;

    public bool isUpgrading = false;
    
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
    public void ChangeSelectedUpgrade(Vector2 input)
    {
        if (isUpgrading)
        {
            if (currentSelectedUpgrade > 0 && input.x < 0)
            {
                currentSelectedUpgrade--;
            }
            if (currentSelectedUpgrade < 2 && input.x > 0)
            {
                currentSelectedUpgrade++;
            }
        }
    }
    public void ConfirmUpgrade()
    {
        if (isUpgrading)
        {
            if (currentSelectedUpgrade == 0)
            {
                UpgradeCharacter(UpgradeSlotOne.GetComponent<MBHoldUpgradeSO>().upgradeSO);
            }
            else if (currentSelectedUpgrade == 1)
            {
                UpgradeCharacter(UpgradeSlotOne.GetComponent<MBHoldUpgradeSO>().upgradeSO);
            }
            else if (currentSelectedUpgrade == 2)
            {
                UpgradeCharacter(UpgradeSlotOne.GetComponent<MBHoldUpgradeSO>().upgradeSO);
            }
            ClearUI();
            isUpgrading = false;
        }
    }
    public void RandomizeThreeUpgrades()
    {
        ClearUI();
        bool isGenerating = true;
        bool cardTwoNotDuped = false;
        bool cardThreeNotDuped = false;
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
        int newSlotTwo = 0 ;
        int newSlotThree = 0;

        UpgradeSlotOne = upgradeCardList[newSlotOne];
        do
        {
            if (cardTwoNotDuped == false)
            {
                newSlotTwo = Random.Range(0, upgradeCardList.Count);
            }
            
            if (upgradeCardList[newSlotTwo].GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName != UpgradeSlotOne.GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName && upgradeCardList[newSlotTwo].GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName != upgradeCardList[newSlotThree].GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName)
            {
                cardTwoNotDuped = true;
            }
            if (cardThreeNotDuped == false)
            {
                newSlotThree = Random.Range(0, upgradeCardList.Count);
            }

            if (upgradeCardList[newSlotThree].GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName != UpgradeSlotOne.GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName && upgradeCardList[newSlotTwo].GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName != upgradeCardList[newSlotThree].GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName)
            {
                cardThreeNotDuped = true;
            }
            if(cardThreeNotDuped && cardTwoNotDuped)
            {
                isGenerating = false;
            }
        } while (isGenerating);


        UpgradeSlotTwo = upgradeCardList[newSlotTwo];
        UpgradeSlotThree = upgradeCardList[newSlotThree];


        UpgradeUIElementOne = Instantiate(UpgradeSlotOne);
        UpgradeUIElementTwo = Instantiate(UpgradeSlotTwo);
        UpgradeUIElementThree = Instantiate(UpgradeSlotThree);


        UpgradeUIElementOne.transform.SetParent(this.gameObject.transform.GetChild(0));
        UpgradeUIElementTwo.transform.SetParent(this.gameObject.transform.GetChild(0));
        UpgradeUIElementThree.transform.SetParent(this.gameObject.transform.GetChild(0));


        Debug.Log(UpgradeSlotOne.GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName);
        Debug.Log(UpgradeSlotTwo.GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName);
        Debug.Log(UpgradeSlotThree.GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName);
    }
    public void ClearUI()
    {
        Destroy(UpgradeUIElementOne);
        Destroy(UpgradeUIElementTwo);
        Destroy(UpgradeUIElementThree);
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
        if (Input.GetKeyDown(KeyCode.U))
        {
            isUpgrading = !isUpgrading;
            if(isUpgrading)
            {
                RandomizeThreeUpgrades();
            }
            else
            {
                ClearUI();
            }
        }
    }
}
