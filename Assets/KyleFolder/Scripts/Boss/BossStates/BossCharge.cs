using UnityEngine;

public class BossCharge : BossState
{
    private Vector3 _lastPosOfPlayer;
    private float _speedOfCharge => boss.BossStatSO.ChargeSpeed;
    private float _timeUntilCharge => boss.BossStatSO.TimeUntilCharge;
    private float _distanceToCountExit => boss.BossStatSO.DistanceCheck;

    private int ChargeTimes;
    
    private float _timer;

    public BossCharge(Boss boss, BossStateMachine bossStateMachine) : base(boss, bossStateMachine) { }

    public override void EnterState()
    {
        base.EnterState();
        boss.MoveEnemy(Vector2.zero);
        _lastPosOfPlayer = playerTransform.position;
        boss.BossAnimator.SetTrigger("Charge");
        _timer = 0f;
        ChargeTimes = 0;
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        if (_timer >= _timeUntilCharge)
        {
            Charge();
        }
        _timer += Time.deltaTime;
    }
    private void Charge()
    {
        Vector2 direction = (((_lastPosOfPlayer + (_lastPosOfPlayer - boss.transform.position)) - (Vector3)boss.transform.position).normalized);
        boss.MoveEnemy(direction * _speedOfCharge);
        
        if (Vector2.Distance(_lastPosOfPlayer, boss.transform.position) <= _distanceToCountExit)
        {
            ChargeTimes++;
            _timer = 0f;
            _lastPosOfPlayer = playerTransform.position;
            boss.MoveEnemy(Vector2.zero);         
            if (ChargeTimes >= 3)
            {
                boss.StateMachine.ChangeState(boss.ChaseState);
            }
            boss.BossAnimator.SetTrigger("Charge");
        }
    }
}
