using UnityEngine;

public class BossCharge : BossState
{
    private Vector3 _lastPosOfPlayer;
    private float SpeedOfCharge = 10f;
    private float _timer;
    private float _timeUntilCharge = 0.5f;
    private float _distanceToCountExit = 2;

    public BossCharge(Boss boss, BossStateMachine bossStateMachine) : base(boss, bossStateMachine) { }

    public override void EnterState()
    {
        base.EnterState();
        boss.MoveEnemy(Vector2.zero);
        _lastPosOfPlayer = playerTransform.position;
        _timer = 0f;
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
            Vector2 direction = (((_lastPosOfPlayer + (_lastPosOfPlayer - boss.transform.position)) - (Vector3)boss.transform.position).normalized);
            boss.MoveEnemy(direction * SpeedOfCharge);
        }

        if (Vector2.Distance(_lastPosOfPlayer, boss.transform.position) <= _distanceToCountExit)
        {
            boss.StateMachine.ChangeState(boss.ChaseState);
        }
        _timer += Time.deltaTime;
    }
}
