using UnityEngine;

public class BossArrowBurst : BossState
{
    private int _numberOfArrows => boss.BossStatSO.NumberOfArrowsBurst;
    private float _arrowSpeed => boss.BossStatSO.ArrowSpeed;
    private float _timeUntilFire => boss.BossStatSO.TimeUntilFireArrow;
    private float _timer;

    public BossArrowBurst(Boss boss, BossStateMachine bossStateMachine) : base(boss, bossStateMachine) { }

    public override void EnterState()
    {
        base.EnterState();
        boss.MoveEnemy(Vector2.zero);
        SpawnArrows(_numberOfArrows);
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
        Debug.Log(_timer);
    }

    private void SpawnArrows(int numberOfArrows)
    {
        for(int i = 0; i < numberOfArrows; i++)
        {
            
            Vector2 direction = ((playerTransform.position + new Vector3(Random.Range(-1.0f, 2.0f), Random.Range(-1.0f, 2.0f), 0)) - boss.transform.position).normalized;
            GameObject shotArrow = GameObject.Instantiate(boss.ArrowPrefab, boss.transform.position, Quaternion.identity);
            shotArrow.GetComponent<Rigidbody2D>().linearVelocity = direction * _arrowSpeed;
            float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            shotArrow.transform.rotation = Quaternion.Euler(0, 0, rot + 180);
            boss.StateMachine.ChangeState(boss.ChaseState);
            _timer = 0f;
        }
    }
}
