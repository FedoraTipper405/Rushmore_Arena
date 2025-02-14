using UnityEngine;

[CreateAssetMenu(fileName = "Enemy-Chase", menuName = "Kyles SOs/Enemy-Chase")]
public class EnemyChasePlayer : EnemyChaseSOBase
{
    public float MovementSpeed => baseEnemy.MovementSpeed;
    public float DistanceFromEnemy = 2f;

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

        if (baseEnemy.IsKnockedBack != true)
        {
            Vector2 moveDirection = (playerTransform.position - baseEnemy.transform.position).normalized;

            baseEnemy.MoveEnemy(moveDirection * MovementSpeed);

            GameObject[] objects = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var obj in objects)
            {
                if (Vector3.Distance(transform.position, obj.transform.position) < DistanceFromEnemy && obj != gameObject)
                {
                    Debug.Log("Correcting position");
                    Vector3 dir = (transform.position - obj.transform.position).normalized;
                    transform.Translate(dir * MovementSpeed * Time.deltaTime);
                }
            }

            if (baseEnemy.IsInRangeToChase != true)
            {
                baseEnemy.StateMachine.ChangeState(baseEnemy.StateMovement);
            }
        }
    }

    public override void Initialize(GameObject gameObject, BaseEnemy baseEnemy)
    {
        base.Initialize(gameObject, baseEnemy);
    }
}
