using UnityEngine;

[CreateAssetMenu(fileName = "Enemy-Use Weapon")]
public class EnemyUseWeapon : EnemyAttackSOBase
{
    public override void DoAnimationTriggerEventLogic(BaseEnemy.AnimationTriggerType triggerType)
    {
        base.DoAnimationTriggerEventLogic(triggerType);
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        Debug.Log("I attack");
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
        Debug.Log("I cant attack");
    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();
        
        baseEnemy.MoveEnemy(Vector2.zero);

        if (baseEnemy.IsInRange != true)
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
