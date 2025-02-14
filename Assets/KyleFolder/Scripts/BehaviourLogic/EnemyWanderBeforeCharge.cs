using UnityEngine;

[CreateAssetMenu(fileName = "Enemy-Wander-Before-Charge", menuName = "Kyles SOs/Enemy-Wander-Before-Charge")]
public class EnemyWanderBeforeCharge : EnemyMovementSOBase
{
    private float MovementSpeed => baseEnemy.MovementSpeed;
    [SerializeField] private float MovementRange;
    private float _timer;
    [SerializeField] public float _timeUntilStop;
    private Vector3 _targetPos;
    private Vector3 _direction;

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        _targetPos = GetRandomPointInCircle();
        _timer = 0f;
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();

        _direction = (_targetPos - baseEnemy.transform.position).normalized;

        baseEnemy.MoveEnemy(_direction * MovementSpeed);

        if ((baseEnemy.transform.position - _targetPos).sqrMagnitude < 0.01f)
        {
            _targetPos = GetRandomPointInCircle();
        }

        if (baseEnemy.ObjectInWay)
        {
            _targetPos = GetRandomPointInCircle();
            baseEnemy.ObjectInTheWay(false);
        }

        if (_timer >= _timeUntilStop)
        {
            baseEnemy.StateMachine.ChangeState(baseEnemy.StateChase);
        }
        _timer += Time.deltaTime;
    }

    public override void Initialize(GameObject gameObject, BaseEnemy baseEnemy)
    {
        base.Initialize(gameObject, baseEnemy);
    }

    private Vector3 GetRandomPointInCircle()
    {
        return baseEnemy.transform.position + (Vector3)UnityEngine.Random.insideUnitCircle * MovementRange;
    }
}
