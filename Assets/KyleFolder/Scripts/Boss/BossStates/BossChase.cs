using UnityEngine;

public class BossChase : BossState
{
    private float _movementSpeed => boss.BossStatSO.MovementSpeed;
    private float _timeUntilStateChange => boss.BossStatSO.TimeUntilStateChange;
    private float _timer;

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

        boss.MoveEnemy(moveDirection * _movementSpeed);
        
        if (_timer >= _timeUntilStateChange)
        {
            int RandomNum = Random.Range(0, 4);

            switch (RandomNum)
            {
                case 0:
                    boss.StateMachine.ChangeState(boss.ChargeState);
                    return;
                case 1:
                    boss.StateMachine.ChangeState(boss.ArrowSpiralState);
                    return;
                case 2:
                    boss.StateMachine.ChangeState(boss.ArrowBurstState);
                    return;
                case 3:
                    boss.StateMachine.ChangeState(boss.GroundSlamState);
                    return;
            }
        }
        _timer += Time.deltaTime;
    }
}
