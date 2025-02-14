using UnityEngine;

public class BossCharge : BossState
{
    private Vector3 _lastPosOfPlayer;
    private float _speedOfCharge => boss.BossStatSO.ChargeSpeed;
    private float _timeUntilCharge => boss.BossStatSO.TimeUntilCharge;
    private float _distanceToCountExit => boss.BossStatSO.DistanceCheck;
    private float _cantReachPlayerTimer => boss.BossStatSO.CantReachPlayerTimer;
    private int _numberOfCharges => boss.BossStatSO.NumberOfCharges;

    private float _timer;
    private float _detectTimer;
    private bool _isCharging;
    private int _chargeTimes;

    public BossCharge(Boss boss, BossStateMachine bossStateMachine) : base(boss, bossStateMachine) { }

    public override void EnterState()
    {
        base.EnterState();
        boss.MoveEnemy(Vector2.zero);
        _lastPosOfPlayer = playerTransform.position;
        boss.BossAnimator.SetTrigger("Charge");
        _timer = 0f;
        _detectTimer = 0f;
        _chargeTimes = 0;
        _isCharging = true;
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        if (_isCharging)
        {
            _detectTimer += Time.deltaTime;
            if(_detectTimer > _cantReachPlayerTimer)
            {
                boss.StateMachine.ChangeState(boss.ChaseState);
                _isCharging = false;
            }
        }
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
            _chargeTimes++;
            _timer = 0f;
            _lastPosOfPlayer = playerTransform.position;
            boss.MoveEnemy(Vector2.zero);         
            if (_chargeTimes >= _numberOfCharges)
            {
                boss.StateMachine.ChangeState(boss.ChaseState);
                _isCharging = false;
            }
            boss.BossAnimator.SetTrigger("Charge");
        }
    }
}
