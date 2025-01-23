using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    public EnemyAttackState(BaseEnemy baseEnemy, EnemyStateMachine enemyStateMachine) : base(baseEnemy, enemyStateMachine)
    {
    
    }

    public override void AnimationTriggerEvent(BaseEnemy.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);

        baseEnemy.EnemyAttackBaseInstance.DoAnimationTriggerEventLogic(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();

        baseEnemy.EnemyAttackBaseInstance.DoEnterLogic();
    }

    public override void ExitState()
    {
        base.ExitState();

        baseEnemy.EnemyAttackBaseInstance.DoExitLogic();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        baseEnemy.EnemyAttackBaseInstance.DoFrameUpdateLogic();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        baseEnemy.EnemyAttackBaseInstance.DoPhysicsLogic();
    }
}
