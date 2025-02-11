using UnityEngine;

public class BossArrowSpiral : BossState
{
    private int numberOfArrows = 8;
    private float arrowSpeed = 5;
    private const float radius = 1f;
    private float _timer;
    private float _timeUntilFire = 3;

    public BossArrowSpiral(Boss boss, BossStateMachine bossStateMachine) : base(boss, bossStateMachine) { }

    public override void EnterState()
    {
        base.EnterState();
        boss.MoveEnemy(Vector2.zero);
        SpawnArrows(numberOfArrows);
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
            SpawnArrows(numberOfArrows);
        }
        _timer += Time.deltaTime;
        Debug.Log(_timer);
    }

    private void SpawnArrows(int numberOfArrows)
    {
        float angleStep = 360f / numberOfArrows;
        float angle = Random.Range(0, 360/numberOfArrows);

        for(int i = 0; i <= numberOfArrows; i++)
        {
            float arrowDirectionXPosition = boss.transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f) * radius;
            float arrowDirectionYPosition = boss.transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f) * radius;

            Vector3 arrowVector = new Vector3(arrowDirectionXPosition, arrowDirectionYPosition, 0);
            Vector3 arrowMoveDirection = (arrowVector - boss.transform.position).normalized * arrowSpeed;
            
            GameObject tempArrow = GameObject.Instantiate(boss.ArrowPrefab, boss.transform.position, Quaternion.identity);
            tempArrow.GetComponent<Rigidbody2D>().linearVelocity = new Vector3(arrowMoveDirection.x, arrowMoveDirection.y, 0);
            float rot = Mathf.Atan2(-arrowMoveDirection.y, -arrowMoveDirection.x) * Mathf.Rad2Deg;
            tempArrow.transform.rotation = Quaternion.Euler(0, 0, rot + 180);

            angle += angleStep;
            _timer = 0f;
        }
    }
}
