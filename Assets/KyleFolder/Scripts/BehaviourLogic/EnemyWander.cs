using UnityEngine;

[CreateAssetMenu(fileName = "Enemy-Wander")]
public class EnemyWander : EnemyMovementSOBase
{
    [SerializeField] private float MovementSpeed;
    [SerializeField] private float MovementRange;

    private Vector3 _targetPos;
    private Vector3 _direction;

    public override void DoAnimationTriggerEventLogic(BaseEnemy.AnimationTriggerType triggerType)
    {
        base.DoAnimationTriggerEventLogic(triggerType);
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        _targetPos = GetRandomPointInCircle();
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();

        _direction = (_targetPos - baseEnemy.transform.position).normalized;

        baseEnemy.MoveEnemy(_direction * MovementSpeed);

        if((baseEnemy.transform.position - _targetPos).sqrMagnitude < 0.01f)
        {
            _targetPos = GetRandomPointInCircle();
        }
        
        if (baseEnemy.IsInRangeToChase)
        {
            baseEnemy.StateMachine.ChangeState(baseEnemy.StateChase);
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

    private Vector3 GetRandomPointInCircle()
    {
        return baseEnemy.transform.position + (Vector3)UnityEngine.Random.insideUnitCircle * MovementRange;
    }
}
