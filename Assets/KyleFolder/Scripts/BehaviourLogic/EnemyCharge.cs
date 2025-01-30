using UnityEngine;

[CreateAssetMenu(fileName = "Enemy-Charge", menuName = "Kyles SOs/Enemy-Charge")]
public class EnemyCharge : EnemyChaseSOBase
{
    private Vector3 _lastPosOfPlayer;
    [SerializeField] public float SpeedOfCharge;
    private float _timer;
    [SerializeField] public float _timeUntilCharge;
    [SerializeField] private float _distanceToCountExit;

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        baseEnemy.MoveEnemy(Vector2.zero);
        _lastPosOfPlayer = playerTransform.position;
        _timer = 0f;
        baseEnemy.EnemyAnimator.SetBool("Charge", true);
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();

        if(_timer >= _timeUntilCharge)
        {
            Vector2 direction = (((_lastPosOfPlayer + (_lastPosOfPlayer - transform.position)) - (Vector3)transform.position).normalized);

            baseEnemy.MoveEnemy(direction * SpeedOfCharge);

            baseEnemy.EnemyAnimator.SetBool("Charge", false);
        }

        if (Vector2.Distance(_lastPosOfPlayer, baseEnemy.transform.position) <= _distanceToCountExit)
        {        
            baseEnemy.StateMachine.ChangeState(baseEnemy.StateMovement);
        }
        _timer += Time.deltaTime;
    }

    public override void DoPhysicsLogic()
    {
        base.DoPhysicsLogic();
    }

    public override void Initialize(GameObject gameObject, BaseEnemy baseEnemy)
    {
        base.Initialize(gameObject, baseEnemy);
    }
}
