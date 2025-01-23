using UnityEngine;

[CreateAssetMenu(fileName = "Enemy-Chase Player")]
public class EnemyChasePlayer : EnemyMovementSOBase
{
    public float MovementSpeed = 1f;
    
    public override void DoAnimationTriggerEventLogic(BaseEnemy.AnimationTriggerType triggerType)
    {
        base.DoAnimationTriggerEventLogic(triggerType);
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();
        
        Vector2 moveDirection = (playerTransform.position - baseEnemy.transform.position).normalized;

        baseEnemy.MoveEnemy(moveDirection * MovementSpeed);

        if (baseEnemy.IsInRange)
        {
            baseEnemy.StateMachine.ChangeState(baseEnemy.StateAttack);
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
