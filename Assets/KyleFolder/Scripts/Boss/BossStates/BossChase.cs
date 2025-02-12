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
            int RandomNum = Random.Range(0, 1);

            switch (RandomNum)
            {
                case 0:
                    boss.StateMachine.ChangeState(boss.GroundSlamState);
                    return;
                case 1:
                    boss.StateMachine.ChangeState(boss.ArrowSpiralState);
                    return;
                case 2:
                    boss.StateMachine.ChangeState(boss.ArrowSpiralState);
                    return;
            }
        }
        _timer += Time.deltaTime;
    }
}
