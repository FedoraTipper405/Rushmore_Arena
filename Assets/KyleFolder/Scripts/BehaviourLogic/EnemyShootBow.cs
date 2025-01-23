using UnityEngine;

[CreateAssetMenu(fileName = "Enemy-Shoot Bow")]
public class EnemyShootBow : EnemyAttackSOBase
{

    [SerializeField] private Rigidbody2D ArrowPrefab;
    [SerializeField] private float _bulletSpeed;

    [SerializeField] private float _timer;
    [SerializeField] private float _timeBetweenShots;
    [SerializeField] private float _exitTimer;
    [SerializeField] private float _timeTillExit;
    [SerializeField] private float _distanceToCountExit;

    public override void DoAnimationTriggerEventLogic(BaseEnemy.AnimationTriggerType triggerType)
    {
        base.DoAnimationTriggerEventLogic(triggerType);
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();

        baseEnemy.MoveEnemy(Vector2.zero);

        if(_timer > _timeBetweenShots)
        {
            _timer = 0f;

            Vector2 dir = (playerTransform.position - baseEnemy.transform.position).normalized;

            Rigidbody2D bullet = GameObject.Instantiate(ArrowPrefab, baseEnemy.transform.position, Quaternion.identity);
            bullet.linearVelocity = dir * _bulletSpeed;
        }

        if(Vector2.Distance(playerTransform.position, baseEnemy.transform.position) > _distanceToCountExit)
        {
            _exitTimer += Time.deltaTime;

            if(_exitTimer > _timeTillExit)
            {
                baseEnemy.StateMachine.ChangeState(baseEnemy.StateMovement);
            }
        }

        else
        {
            _exitTimer = 0f;
        }

        _timer += Time.deltaTime;
    }

    public override void DoPhysicsLogic()
    {
        base.DoPhysicsLogic();
    }

    public override void Initialize(GameObject gameObject, BaseEnemy baseEnemy)
    {
        base.Initialize(gameObject, baseEnemy);
    }
}
