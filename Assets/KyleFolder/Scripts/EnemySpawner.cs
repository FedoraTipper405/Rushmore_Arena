using System.Collections;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;

    [SerializeField] private Transform BossSpawnPoint;

    [SerializeField] private GameObject[] enemiesToSpawn;
    
    [SerializeField] private GameObject BossPrefab;

    [SerializeField] private int _amountOfSpawns;

    [SerializeField] private int[] enemySpawns = new int[5];

    [SerializeField] private int[] enemyAmountsWhenSpawned;

    [SerializeField] private bool[] isSpawningType = new bool[5];

    [SerializeField]  MBWaveManager waveManager;

    [SerializeField] SODifficulty difficultySO;
    public int difficultyCounter;

    private void Start()
    {
        MakeNewSpawnList();
    }
    

    public void MakeNewSpawnList()
    {
        if(waveManager.CurrentWave == difficultySO.wavesForDifficulty[difficultySO.difficultyIndex])
        {
            StartCoroutine(SpawnBoss());
        }
        else
        {
            for (int i = 0; i < enemySpawns.Length; i++)
            {
                enemySpawns[i] = 0;
            }
            for (int i = 0; i < isSpawningType.Length; i++)
            {
                isSpawningType[i] = false;
            }

            for (int i = 0; i < difficultyCounter; i++)
            {
                int enemyAdded = Random.Range(0, enemiesToSpawn.Length);
                enemySpawns[enemyAdded] += enemyAmountsWhenSpawned[enemyAdded];
                isSpawningType[enemyAdded] = true;

            }
            //      Debug.Log("Starting Couro");
            StartCoroutine(SpawnTimer());
        }
       
    }

    private void SpawnEnemy()
    {
        int RandomSpawnPoint = Random.Range(0, spawnPoints.Length);
        bool hasFoundToSpawn = false;
        bool nothingToSpawn = true;
        int tryThis = 0;
      //  Debug.Log("Started Spawn Enemy");
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
      //  Debug.Log(nothingToSpawn);
        
        if(nothingToSpawn == false)
        {
            enemySpawns[tryThis]--;
           GameObject lastEnemy = Instantiate(enemiesToSpawn[tryThis], spawnPoints[RandomSpawnPoint].position, Quaternion.identity);
            lastEnemy.GetComponent<BaseEnemy>().waveManager = waveManager;
        }
        
    }

    IEnumerator SpawnTimer()
    {
        _amountOfSpawns = 0;

       for(int i = 0; i < enemySpawns.Length; i++)
        {
            _amountOfSpawns += enemySpawns[i];
        }
        waveManager.EnemiesInScene = _amountOfSpawns;
        for (int i = 0; i < _amountOfSpawns; i++)
        {
            yield return new WaitForSeconds(3/(difficultySO.difficultyIndex+1));
            
            SpawnEnemy();
        }
    }

    IEnumerator SpawnBoss()
    {
        yield return new WaitForSeconds(4f);
        GameObject bossPrefab = Instantiate(BossPrefab, BossSpawnPoint.position, Quaternion.identity);
    }
}
