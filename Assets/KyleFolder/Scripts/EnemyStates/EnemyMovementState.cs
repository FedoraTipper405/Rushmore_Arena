using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementState : EnemyState
{
    public EnemyMovementState(BaseEnemy baseEnemy, EnemyStateMachine enemyStateMachine) : base(baseEnemy, enemyStateMachine) { }

    public override void EnterState()
    {
        base.EnterState();

        baseEnemy.EnemyMovementBaseInstance.DoEnterLogic();
    }

    public override void ExitState()
    {
        base.ExitState();

        baseEnemy.EnemyMovementBaseInstance.DoExitLogic();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        baseEnemy.EnemyMovementBaseInstance.DoFrameUpdateLogic();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        baseEnemy.EnemyMovementBaseInstance.DoPhysicsLogic();
    }
}
