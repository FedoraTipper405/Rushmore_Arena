using UnityEngine;

public class EnemyChaseState : EnemyState
{
    public EnemyChaseState(BaseEnemy baseEnemy, EnemyStateMachine enemyStateMachine) : base(baseEnemy, enemyStateMachine) { }

    public override void EnterState()
    {
        base.EnterState();

        baseEnemy.EnemyChaseBaseInstance.DoEnterLogic();
    }

    public override void ExitState()
    {
        base.ExitState();

        baseEnemy.EnemyChaseBaseInstance.DoExitLogic();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        baseEnemy.EnemyChaseBaseInstance.DoFrameUpdateLogic();
    }
}
