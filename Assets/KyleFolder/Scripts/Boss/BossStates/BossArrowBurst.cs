using UnityEngine;

public class BossArrowBurst : BossState
{
    private int _numberOfArrows => boss.BossStatSO.NumberOfArrowsBurst;
    private float _arrowSpeed => boss.BossStatSO.ArrowSpeed;
    private float _timeUntilFire => boss.BossStatSO.TimeUntilFireArrow;
    private float _arrowDamage => boss.BossStatSO.ArrowDamage;
    private int _arrowBurstTimes => boss.BossStatSO.ArrowBurstTimes;
    
    private float _timer;
    private int _shotTimes;

    public BossArrowBurst(Boss boss, BossStateMachine bossStateMachine) : base(boss, bossStateMachine) { }

    public override void EnterState()
    {
        base.EnterState();
        boss.MoveEnemy(Vector2.zero);
        _shotTimes = 0;
        _timer = 0f;
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        if(_timer >= _timeUntilFire)
        {
            SpawnArrows(_numberOfArrows);
        }
        _timer += Time.deltaTime;
    }

    private void SpawnArrows(int numberOfArrows)
    {
        boss.BossAnimator.SetTrigger("ArrowShot");
        for (int i = 0; i < numberOfArrows; i++)
        {
            Vector2 direction = ((playerTransform.position + new Vector3(Random.Range(-1.0f, 2.0f), Random.Range(-1.0f, 2.0f), 0)) - boss.transform.position).normalized;
            GameObject shotArrow = GameObject.Instantiate(boss.ArrowPrefab, boss.transform.position, Quaternion.identity);
            shotArrow.GetComponent<Rigidbody2D>().linearVelocity = direction * _arrowSpeed;
            shotArrow.GetComponent<ArrowLogic>().arrowDamage = _arrowDamage;
            float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            shotArrow.transform.rotation = Quaternion.Euler(0, 0, rot + 180);
        }
        _timer = 0f;
        _shotTimes++;
        if (_shotTimes >= _arrowBurstTimes)
        {
            boss.StateMachine.ChangeState(boss.ChaseState);
        }
    }
}
