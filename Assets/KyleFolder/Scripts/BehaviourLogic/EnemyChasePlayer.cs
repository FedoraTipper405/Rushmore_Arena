using UnityEngine;

[CreateAssetMenu(fileName = "Enemy-Chase", menuName = "Kyles SOs/Enemy-Chase")]
public class EnemyChasePlayer : EnemyChaseSOBase
{
    public float MovementSpeed = 1f;

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
        
        if (baseEnemy.IsInRangeToChase != true)
        {
            baseEnemy.StateMachine.ChangeState(baseEnemy.StateMovement);
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
