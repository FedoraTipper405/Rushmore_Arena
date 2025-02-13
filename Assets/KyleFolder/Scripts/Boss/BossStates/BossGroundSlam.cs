using System.Collections;
using UnityEngine;

public class BossGroundSlam : BossState
{
    private float _radiusOfGroundSlam => boss.BossStatSO.RadiusOfGroundSlam;
    private float _groundSlamDamage => boss.BossStatSO.BossMeleeDamage;

    private int SlamTimes;

    private float _timer;
    public BossGroundSlam(Boss boss, BossStateMachine bossStateMachine) : base(boss, bossStateMachine) { }

    public override void EnterState()
    {
        base.EnterState();
        boss.MoveEnemy(Vector2.zero);
        _timer = 0f;
        SlamTimes = 0;
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        if (_timer >= 1f)
        {
            GroundSlam();
        }
        _timer += Time.deltaTime;
    }

    private void GroundSlam()
    {
        boss.BossAnimator.SetTrigger("GroundSlam");
        Collider2D[] colliders = Physics2D.OverlapCircleAll(boss.transform.position, _radiusOfGroundSlam);
        foreach (Collider2D hit in colliders)
        {
            IDamageablePlayer damageable = hit.gameObject.GetComponent<IDamageablePlayer>();
            if (damageable != null)
            {
                damageable.DamageToPlayerHealth(_groundSlamDamage);
                Debug.Log("player");
            }
            else
            {
                Debug.Log("no player");
            }
        }
        SlamTimes++;
        _timer = 0f;
        if (SlamTimes >= 3)
        {
            boss.StateMachine.ChangeState(boss.ChaseState);
        }
    }
}
