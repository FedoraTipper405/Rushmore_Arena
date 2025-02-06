using UnityEngine;

public class BossChase : BossState
{
    private float MovementSpeed = 1f;
    private float _timer;
    private float _timeUntilStop = 4f;

    public BossChase(Boss boss, BossStateMachine bossStateMachine) : base(boss, bossStateMachine) { }

    public override void EnterState()
    {
        base.EnterState();
        _timer = 0f;
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        
        Vector2 moveDirection = (playerTransform.position - boss.transform.position).normalized;

        boss.MoveEnemy(moveDirection * MovementSpeed);
        
        if (_timer >= _timeUntilStop)
        {
            boss.StateMachine.ChangeState(boss.ArrowSpiralState);
        }
        _timer += Time.deltaTime;
    }
}
