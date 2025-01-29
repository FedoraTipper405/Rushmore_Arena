using System.Collections;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    
    [SerializeField] private GameObject[] enemiesToSpawn;

    [SerializeField] private int _amountOfSpawns;

    [SerializeField] private int[] enemySpawns = new int[5];

    [SerializeField] private int[] enemyAmountsWhenSpawned;

    [SerializeField] private bool[] isSpawningType = new bool[5];

    //private int _swordSpawns; 0
    //private int _spearSpawns; 1
    //private int _rhinoSpawns; 2
    //private int _lionSpawns; 3
    //private int _bowSpawns; 4

    //[SerializeField] private int _swordAmount;
    //[SerializeField] private int _spearAmount;
    //[SerializeField] private int _rhinoAmount;
    //[SerializeField] private int _lionAmount;
    //[SerializeField] private int _bowAmount;

    //private bool _isSpawningSword;
    //private bool _isSpawningSpear;
    //private bool _isSpawningRhino;
    //private bool _isSpawningLion;
    //private bool _isSpawningBow;

    public int difficultyCounter;

    private void Start()
    {
        MakeNewSpawnList();
    }

    public void MakeNewSpawnList()
    {
        for(int i = 0; i < enemySpawns.Length; i++)
        {
            enemySpawns[i] = 0;
        }
        for(int i = 0; i < isSpawningType.Length; i++)
        {
            isSpawningType[i] = false;
        }

        for (int i = 0; i < difficultyCounter; i++)
        {
            int enemyAdded = Random.Range(0, enemiesToSpawn.Length);
            enemySpawns[enemyAdded] += enemyAmountsWhenSpawned[enemyAdded];
            isSpawningType[enemyAdded] = true;

        }
        Debug.Log("Starting Couro");
        StartCoroutine(SpawnTimer());
    }

    private void SpawnEnemy()
    {
        int RandomSpawnPoint = Random.Range(0, spawnPoints.Length);
        bool hasFoundToSpawn = false;
        bool nothingToSpawn = true;
        int tryThis = 0;
        Debug.Log("Started Spawn Enemy");
        for (int i = 0; i < enemySpawns.Length; i++)
        {
            if (enemySpawns[i] <= 0)
            {
                isSpawningType[i] = false;
            }
            else
            {
                nothingToSpawn = false;
            }
        }
        int stopLoss = 0;
        do
        {
            stopLoss++;
            tryThis = Random.Range(0, isSpawningType.Length);
            if (isSpawningType[tryThis])
            {
                hasFoundToSpawn = true;
            }
        } while (hasFoundToSpawn == false && nothingToSpawn == false && stopLoss < 30);
        Debug.Log(nothingToSpawn);
        
        if(nothingToSpawn == false)
        {
            enemySpawns[tryThis]--;
            Instantiate(enemiesToSpawn[tryThis], spawnPoints[RandomSpawnPoint].position, Quaternion.identity);
        }
        
    }

    IEnumerator SpawnTimer()
    {
        _amountOfSpawns = 0;

       for(int i = 0; i < enemySpawns.Length; i++)
        {
            _amountOfSpawns += enemySpawns[i];
        }
        for (int i = 0; i < _amountOfSpawns; i++)
        {
            yield return new WaitForSeconds(2);
            
            SpawnEnemy();
        }
    }
}
