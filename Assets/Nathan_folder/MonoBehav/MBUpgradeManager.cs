
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MBUpgradeManager : MonoBehaviour
{
    [SerializeField] List<GameObject> washingtonUpgradeCardList = new List<GameObject>();
    [SerializeField] List<GameObject> abeUpgradeCardList = new List<GameObject>();
    [SerializeField] List<GameObject> teddyUpgradeCardList = new List<GameObject>();
    [SerializeField] List<GameObject> jeffyUpgradeCardList = new List<GameObject>();

     List<SOUpgradeCards> washingtonUpgradeSOList = new List<SOUpgradeCards>();
     List<SOUpgradeCards> abeUpgradeSOList = new List<SOUpgradeCards>();
     List<SOUpgradeCards> teddyUpgradeSOList = new List<SOUpgradeCards>();
     List<SOUpgradeCards> jeffyUpgradeSOList = new List<SOUpgradeCards>();

    [SerializeField] GameObject[] presidentUniqueCardsOne = new GameObject[4];
    SOUpgradeCards[] presidentUniqueCardsSOsOne = new SOUpgradeCards[4];
    GameObject currentPresidentUniqueCardOne;
    SOUpgradeCards currentPresidentsUniqueCardSOOne;

    public int currentSelectedUpgrade = 0;

    public int cardSlotOneIndex;
    public int cardSlotTwoIndex;
    public int cardSlotThreeIndex;

    
    [SerializeField] MBBasePlayerController[] presidentControllers = new MBBasePlayerController[4];
    private MBBasePlayerController selectedPresident;

    //index 0 = washington, 1 = abe, 2 = teddy, jeffy = 3
    private int selectedPresidentIndex;

    private GameObject UpgradeSlotOne;
    private GameObject UpgradeSlotTwo;
    private GameObject UpgradeSlotThree;

    private GameObject UpgradeUIElementOne;
    private GameObject UpgradeUIElementTwo;
    private GameObject UpgradeUIElementThree;

    public bool isUpgrading = false;
    public bool isWaitingToUpgrade = false;

    public List<SOUpgradeCards> chosenUpgrades = new List<SOUpgradeCards>();

    [SerializeField] GameObject selectionParent;
    [SerializeField] GameObject[] selectorIcons = new GameObject[3];

    [SerializeField] EnemySpawner enemySpawner;

    [SerializeField]GameObject UpgradingTimeText;





    
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
                selectedPresidentIndex = i;
                currentPresidentUniqueCardOne = presidentUniqueCardsOne[i];
                currentPresidentsUniqueCardSOOne = presidentUniqueCardsOne[i].GetComponent<MBHoldUpgradeSO>().upgradeSO;
                
            }
        }
        if (selectedPresidentIndex == 0)
        {
            for (int i = 0; i < washingtonUpgradeCardList.Count; i++)
            {
                washingtonUpgradeSOList.Add(washingtonUpgradeCardList[i].GetComponent<MBHoldUpgradeSO>().upgradeSO);
            }
        } 
        else if (selectedPresidentIndex == 1)
        {
            for (int i = 0; i < abeUpgradeCardList.Count; i++)
            {
                abeUpgradeSOList.Add(abeUpgradeCardList[i].GetComponent<MBHoldUpgradeSO>().upgradeSO);
            }
        } 
        else if (selectedPresidentIndex == 2)
        {
            for (int i = 0; i < teddyUpgradeCardList.Count; i++)
            {
                teddyUpgradeSOList.Add(teddyUpgradeCardList[i].GetComponent<MBHoldUpgradeSO>().upgradeSO);
            }
        } 
        else if (selectedPresidentIndex == 3)
        {
            for (int i = 0; i < jeffyUpgradeCardList.Count; i++)
            {
                jeffyUpgradeSOList.Add(jeffyUpgradeCardList[i].GetComponent<MBHoldUpgradeSO>().upgradeSO);
            }
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
            for(int i = 0; i < selectorIcons.Length; i++)
            {
                if(i == currentSelectedUpgrade)
                {
                    selectorIcons[i].GetComponent<Image>().color = new Vector4(1,1,1,1);
                }
                else
                {
                    selectorIcons[i].GetComponent<Image>().color = new Vector4(1, 1, 1, 0);
                }
            }
        }
    }
    public void ConfirmUpgrade()
    {
        if (isUpgrading && isWaitingToUpgrade == false)
        {
            if (currentSelectedUpgrade == 0)
            {
                UpgradeCharacter(UpgradeSlotOne.GetComponent<MBHoldUpgradeSO>().upgradeSO);
                chosenUpgrades.Add(UpgradeSlotOne.GetComponent<MBHoldUpgradeSO>().upgradeSO);
                if(UpgradeSlotOne.GetComponent<MBHoldUpgradeSO>().upgradeSO.isOneTimeCard)
                {
                 if(selectedPresidentIndex == 0)
                    {
                        washingtonUpgradeCardList.RemoveAt(cardSlotOneIndex);
                    }
                    else if (selectedPresidentIndex == 1)
                    {
                        abeUpgradeCardList.RemoveAt(cardSlotOneIndex);
                    }
                    else if (selectedPresidentIndex == 2)
                    {
                        teddyUpgradeCardList.RemoveAt(cardSlotOneIndex);
                    }
                    else if (selectedPresidentIndex == 3)
                    {
                        jeffyUpgradeCardList.RemoveAt(cardSlotOneIndex);
                    }
                }
            }
            else if (currentSelectedUpgrade == 1)
            {
                UpgradeCharacter(UpgradeSlotTwo.GetComponent<MBHoldUpgradeSO>().upgradeSO);
                chosenUpgrades.Add(UpgradeSlotTwo.GetComponent<MBHoldUpgradeSO>().upgradeSO);
                if (UpgradeSlotTwo.GetComponent<MBHoldUpgradeSO>().upgradeSO.isOneTimeCard)
                {
                    if (selectedPresidentIndex == 0)
                    {
                        washingtonUpgradeCardList.RemoveAt(cardSlotTwoIndex);
                    }
                    else if (selectedPresidentIndex == 1)
                    {
                        abeUpgradeCardList.RemoveAt(cardSlotTwoIndex);
                    }
                    else if (selectedPresidentIndex == 2)
                    {
                        teddyUpgradeCardList.RemoveAt(cardSlotTwoIndex);
                    }
                    else if (selectedPresidentIndex == 3)
                    {
                        jeffyUpgradeCardList.RemoveAt(cardSlotTwoIndex);
                    }
                }
            }
            else if (currentSelectedUpgrade == 2)
            {
                UpgradeCharacter(UpgradeSlotThree.GetComponent<MBHoldUpgradeSO>().upgradeSO);
                chosenUpgrades.Add(UpgradeSlotThree.GetComponent<MBHoldUpgradeSO>().upgradeSO);
                if (UpgradeSlotTwo.GetComponent<MBHoldUpgradeSO>().upgradeSO.isOneTimeCard)
                {
                    if (selectedPresidentIndex == 0)
                    {
                        washingtonUpgradeCardList.RemoveAt(cardSlotThreeIndex);
                    }
                    else if (selectedPresidentIndex == 1)
                    {
                        abeUpgradeCardList.RemoveAt(cardSlotThreeIndex);
                    }
                    else if (selectedPresidentIndex == 2)
                    {
                        teddyUpgradeCardList.RemoveAt(cardSlotThreeIndex);
                    }
                    else if (selectedPresidentIndex == 3)
                    {
                        jeffyUpgradeCardList.RemoveAt(cardSlotThreeIndex);
                    }
                }
            }
            ChangeUpgradingState();
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

        if (selectedPresidentIndex == 0)
        {
            int newSlotOne = Random.Range(0, washingtonUpgradeCardList.Count);
            int newSlotTwo = 0;
            int newSlotThree = 0;

            UpgradeSlotOne = washingtonUpgradeCardList[newSlotOne];
            do
            {
                if (cardTwoNotDuped == false)
                {
                    newSlotTwo = Random.Range(0, washingtonUpgradeCardList.Count);
                }

                if (washingtonUpgradeCardList[newSlotTwo].GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName != UpgradeSlotOne.GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName && washingtonUpgradeCardList[newSlotTwo].GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName != washingtonUpgradeCardList[newSlotThree].GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName)
                {
                    cardTwoNotDuped = true;
                }
                if (cardThreeNotDuped == false)
                {
                    newSlotThree = Random.Range(0, washingtonUpgradeCardList.Count);
                }

                if (washingtonUpgradeCardList[newSlotThree].GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName != UpgradeSlotOne.GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName && washingtonUpgradeCardList[newSlotTwo].GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName != washingtonUpgradeCardList[newSlotThree].GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName)
                {
                    cardThreeNotDuped = true;
                }
                if (cardThreeNotDuped && cardTwoNotDuped)
                {
                    isGenerating = false;
                }
            } while (isGenerating);


            UpgradeSlotTwo = washingtonUpgradeCardList[newSlotTwo];
            UpgradeSlotThree = washingtonUpgradeCardList[newSlotThree];

            cardSlotOneIndex = newSlotOne;
            cardSlotTwoIndex = newSlotTwo;
            cardSlotThreeIndex = newSlotThree;

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
        else if (selectedPresidentIndex == 1)
        {
            int newSlotOne = Random.Range(0, abeUpgradeCardList.Count);
            int newSlotTwo = 0;
            int newSlotThree = 0;

            UpgradeSlotOne = abeUpgradeCardList[newSlotOne];
            do
            {
                if (cardTwoNotDuped == false)
                {
                    newSlotTwo = Random.Range(0, abeUpgradeCardList.Count);
                }

                if (abeUpgradeCardList[newSlotTwo].GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName != UpgradeSlotOne.GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName && abeUpgradeCardList[newSlotTwo].GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName != abeUpgradeCardList[newSlotThree].GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName)
                {
                    cardTwoNotDuped = true;
                }
                if (cardThreeNotDuped == false)
                {
                    newSlotThree = Random.Range(0, abeUpgradeCardList.Count);
                }

                if (abeUpgradeCardList[newSlotThree].GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName != UpgradeSlotOne.GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName && abeUpgradeCardList[newSlotTwo].GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName != abeUpgradeCardList[newSlotThree].GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName)
                {
                    cardThreeNotDuped = true;
                }
                if (cardThreeNotDuped && cardTwoNotDuped)
                {
                    isGenerating = false;
                }
            } while (isGenerating);


            UpgradeSlotTwo = abeUpgradeCardList[newSlotTwo];
            UpgradeSlotThree = abeUpgradeCardList[newSlotThree];

            cardSlotOneIndex = newSlotOne;
            cardSlotTwoIndex = newSlotTwo;
            cardSlotThreeIndex = newSlotThree;

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
        else if (selectedPresidentIndex == 2)
        {
            int newSlotOne = Random.Range(0, teddyUpgradeCardList.Count);
            int newSlotTwo = 0;
            int newSlotThree = 0;

            UpgradeSlotOne = teddyUpgradeCardList[newSlotOne];
            do
            {
                if (cardTwoNotDuped == false)
                {
                    newSlotTwo = Random.Range(0, teddyUpgradeCardList.Count);
                }

                if (teddyUpgradeCardList[newSlotTwo].GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName != UpgradeSlotOne.GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName && teddyUpgradeCardList[newSlotTwo].GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName != teddyUpgradeCardList[newSlotThree].GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName)
                {
                    cardTwoNotDuped = true;
                }
                if (cardThreeNotDuped == false)
                {
                    newSlotThree = Random.Range(0, teddyUpgradeCardList.Count);
                }

                if (teddyUpgradeCardList[newSlotThree].GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName != UpgradeSlotOne.GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName && teddyUpgradeCardList[newSlotTwo].GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName != teddyUpgradeCardList[newSlotThree].GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName)
                {
                    cardThreeNotDuped = true;
                }
                if (cardThreeNotDuped && cardTwoNotDuped)
                {
                    isGenerating = false;
                }
            } while (isGenerating);


            UpgradeSlotTwo = teddyUpgradeCardList[newSlotTwo];
            UpgradeSlotThree = teddyUpgradeCardList[newSlotThree];

            cardSlotOneIndex = newSlotOne;
            cardSlotTwoIndex = newSlotTwo;
            cardSlotThreeIndex = newSlotThree;

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
        else if (selectedPresidentIndex == 3)
        {
            int newSlotOne = Random.Range(0, jeffyUpgradeCardList.Count);
            int newSlotTwo = 0;
            int newSlotThree = 0;

            UpgradeSlotOne = jeffyUpgradeCardList[newSlotOne];
            do
            {
                if (cardTwoNotDuped == false)
                {
                    newSlotTwo = Random.Range(0, jeffyUpgradeCardList.Count);
                }

                if (jeffyUpgradeCardList[newSlotTwo].GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName != UpgradeSlotOne.GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName && jeffyUpgradeCardList[newSlotTwo].GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName != jeffyUpgradeCardList[newSlotThree].GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName)
                {
                    cardTwoNotDuped = true;
                }
                if (cardThreeNotDuped == false)
                {
                    newSlotThree = Random.Range(0, jeffyUpgradeCardList.Count);
                }

                if (teddyUpgradeCardList[newSlotThree].GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName != UpgradeSlotOne.GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName && jeffyUpgradeCardList[newSlotTwo].GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName != jeffyUpgradeCardList[newSlotThree].GetComponent<MBHoldUpgradeSO>().upgradeSO.CardName)
                {
                    cardThreeNotDuped = true;
                }
                if (cardThreeNotDuped && cardTwoNotDuped)
                {
                    isGenerating = false;
                }
            } while (isGenerating);


            UpgradeSlotTwo = jeffyUpgradeCardList[newSlotTwo];
            UpgradeSlotThree = jeffyUpgradeCardList[newSlotThree];

            cardSlotOneIndex = newSlotOne;
            cardSlotTwoIndex = newSlotTwo;
            cardSlotThreeIndex = newSlotThree;

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
       
    }
    public void ClearUI()
    {
        Destroy(UpgradeUIElementOne);
        Destroy(UpgradeUIElementTwo);
        Destroy(UpgradeUIElementThree);
    }
    public void UpgradeCharacter(SOUpgradeCards selectedUpgrade)
    {
        if (selectedUpgrade.isUniqueCardOne)
        {
            //need to remove unique upgrade from upgrade pool. Must also make the upgrade pools work for the different upgrades (Ranged upgrade, uniques, etc.)
        }
        selectedPresident.moveSpeed += selectedUpgrade.moveSpeedUpgrade;
        selectedPresident.attackDamage += selectedUpgrade.attackDamageUpgrade;
        selectedPresident.attackSpeed += selectedUpgrade.attackSpeedUpgrade;
       
        selectedPresident.healthUpgrade += selectedUpgrade.healthUpgrade;
        selectedPresident.healthBar.SetMaxHealth(selectedPresident.health);
        
        selectedPresident.attackRange += selectedUpgrade.attackRangeUpgrade;
        selectedPresident.projectileAmount += selectedUpgrade.projectileAmountUpgrade;
        selectedPresident.projectileSpeed += selectedUpgrade.projectileSpeedUpgrade;
        selectedPresident.projectileSize += selectedUpgrade.projectileSizeUpgrade;
        selectedPresident.knockBack += selectedUpgrade.knockBackUpgrade;
        selectedPresident.penetration += selectedUpgrade.penetrationUpgrade;
        selectedPresident.hasUniqueCardOne = selectedUpgrade.isUniqueCardOne;
        selectedPresident.projectileSpread += selectedUpgrade.spread;
        
    }
    private void ChangeSelectionDisplayState()
    {
        if (isUpgrading)
        {
            selectionParent.SetActive(true);
        }
        else
        {
            selectionParent.SetActive(false);
        }
    }
    public void ChangeUpgradingState()
    {
        if (isWaitingToUpgrade == false)
        {

        
            isUpgrading = !isUpgrading;
            selectedPresident.isUpgrading = isUpgrading;
            selectedPresident.healthBar.SetHealth(selectedPresident.health);
        
            if (isUpgrading)
            {
                StartCoroutine(StartUpgrading());
            }
            else
            {
                enemySpawner.MakeNewSpawnList();
                ChangeSelectionDisplayState();
                ClearUI();
            }

        }

    }
    IEnumerator StartUpgrading()
    {
        isWaitingToUpgrade = true;
        UpgradingTimeText.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        isWaitingToUpgrade = false;
        UpgradingTimeText.SetActive(false);
        RandomizeThreeUpgrades();
        currentSelectedUpgrade = 0;
        for (int i = 0; i < selectorIcons.Length; i++)
        {
            if (i == currentSelectedUpgrade)
            {
                selectorIcons[i].GetComponent<Image>().color = new Vector4(1, 1, 1, 1);
            }
            else
            {
                selectorIcons[i].GetComponent<Image>().color = new Vector4(1, 1, 1, 0);
            }
        }
        ChangeSelectionDisplayState();
    }
    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.U))
        {
            ChangeUpgradingState();
        }*/
    }
}
