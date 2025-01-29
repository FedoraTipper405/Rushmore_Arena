using UnityEngine;

[CreateAssetMenu(fileName = "Enemy-Charge Player")]
public class EnemyCharge : EnemyChaseSOBase
{
    private Vector3 _lastPosOfPlayer;
    [SerializeField] public float SpeedOfCharge;
    private float _timer;
    [SerializeField] public float _timeUntilCharge;
    [SerializeField] public bool InRange = false;
    [SerializeField] private float _distanceToCountExit;

    public override void DoAnimationTriggerEventLogic(BaseEnemy.AnimationTriggerType triggerType)
    {
        base.DoAnimationTriggerEventLogic(triggerType);
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        baseEnemy.MoveEnemy(Vector2.zero);
        InRange = true;
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
            _timer = 0f;

            _lastPosOfPlayer = playerTransform.position;

            Vector2 direction = (((_lastPosOfPlayer + (_lastPosOfPlayer - transform.position)) - (Vector3)transform.position).normalized);

            baseEnemy.MoveEnemy(direction * SpeedOfCharge);
        }

        if (Vector2.Distance(_lastPosOfPlayer, baseEnemy.transform.position) <= _distanceToCountExit)
        {        
            baseEnemy.StateMachine.ChangeState(baseEnemy.StateMovement);
            InRange = true;
            _timer = 0f;
        }

        if (InRange == true)
        {
            _timer += Time.deltaTime;
        }
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
