using UnityEngine;

public class MBWaveManager : MonoBehaviour
{

    public float Kills;
    public int EnemiesInScene;
    public int CurrentWave = 1;
    [SerializeField] private MBUpgradeManager upgradeManager;
    [SerializeField] private EnemySpawner spawner;

    //temp solution. Needs to be fixed for when there is more that one president
    [SerializeField] private MBBasePlayerController playerController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void EnemyKilled()
    {
        Kills++;
        if(Kills >= EnemiesInScene)
        {
            
            Kills = 0;
            CurrentWave++;
            playerController.ResetPlayerPerRound();
            spawner.difficultyCounter = (int)Mathf.Ceil(CurrentWave / 2);
            upgradeManager.ChangeUpgradingState();
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
