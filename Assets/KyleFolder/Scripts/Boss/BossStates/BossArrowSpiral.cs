using UnityEngine;

public class BossArrowSpiral : BossState
{
    private int _numberOfArrows => boss.BossStatSO.NumberOfArrowsSpiral;
    private float _arrowSpeed => boss.BossStatSO.ArrowSpeed;
    private float _timeUntilFire => boss.BossStatSO.TimeUntilFireArrow;
    private float _arrowDamage => boss.BossStatSO.ArrowDamage;
    private int _arrowSpiralTimes => boss.BossStatSO.ArrowSpiralTimes;

    private const float radius = 1f;
    private int _shotTimes;
    private float _timer;

    public BossArrowSpiral(Boss boss, BossStateMachine bossStateMachine) : base(boss, bossStateMachine) { }

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
        if (_timer >= _timeUntilFire)
        {
            SpawnArrows(_numberOfArrows);
        }
        _timer += Time.deltaTime;
    }

    private void SpawnArrows(int numberOfArrows)
    {
        boss.BossAnimator.SetTrigger("ArrowShot");
        float angleStep = 360f / numberOfArrows;
        float angle = Random.Range(0, 360/numberOfArrows);

        for(int i = 0; i <= numberOfArrows; i++)
        {
            float arrowDirectionXPosition = boss.transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f) * radius;
            float arrowDirectionYPosition = boss.transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f) * radius;

            Vector3 arrowVector = new Vector3(arrowDirectionXPosition, arrowDirectionYPosition, 0);
            Vector3 arrowMoveDirection = (arrowVector - boss.transform.position).normalized * _arrowSpeed;
            
            GameObject shotArrow = GameObject.Instantiate(boss.ArrowPrefab, boss.transform.position, Quaternion.identity);
            shotArrow.GetComponent<Rigidbody2D>().linearVelocity = new Vector3(arrowMoveDirection.x, arrowMoveDirection.y, 0);
            shotArrow.GetComponent<ArrowLogic>().arrowDamage = _arrowDamage;
            float rot = Mathf.Atan2(-arrowMoveDirection.y, -arrowMoveDirection.x) * Mathf.Rad2Deg;
            shotArrow.transform.rotation = Quaternion.Euler(0, 0, rot + 180);

            angle += angleStep;
        }
        _timer = 0f;
        _shotTimes++;
        if (_shotTimes >= _arrowSpiralTimes)
        {
            boss.StateMachine.ChangeState(boss.ChaseState);
        }
    }
}
