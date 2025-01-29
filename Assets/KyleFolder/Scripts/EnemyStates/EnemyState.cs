using UnityEngine;

public class EnemyState
{
    protected BaseEnemy baseEnemy;
    protected EnemyStateMachine enemyStateMachine;

    public EnemyState(BaseEnemy baseEnemy, EnemyStateMachine enemyStateMachine)
    {
        this.baseEnemy = baseEnemy;
        this.enemyStateMachine = enemyStateMachine;
    }

    public virtual void EnterState() { }
    public virtual void ExitState() { }
    public virtual void FrameUpdate() { }
    public virtual void PhysicsUpdate() { }
}
