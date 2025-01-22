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
    }

    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("I attack");
    }

    public override void ExitState()
    {
        base.ExitState();
        Debug.Log("I cant attack");
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        baseEnemy.MoveEnemy(Vector2.zero);

        if (baseEnemy.IsInRange != true)
        {
            baseEnemy.StateMachine.ChangeState(baseEnemy.StateMovement);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
