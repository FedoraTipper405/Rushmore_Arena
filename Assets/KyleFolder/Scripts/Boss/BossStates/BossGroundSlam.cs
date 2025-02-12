using System.Collections;
using UnityEngine;

public class BossGroundSlam : BossState
{
    private float _radiusOfGroundSlam => boss.BossStatSO.RadiusOfGroundSlam;
    private float _groundSlamDamage => boss.BossStatSO.BossMeleeDamage;
    public BossGroundSlam(Boss boss, BossStateMachine bossStateMachine) : base(boss, bossStateMachine) { }

    public override void EnterState()
    {
        base.EnterState();
        Collider2D[] colliders = Physics2D.OverlapCircleAll(boss.transform.position, _radiusOfGroundSlam);
        foreach(Collider2D hit in colliders)
        {
            IDamageablePlayer damageable = hit.gameObject.GetComponent<IDamageablePlayer>();
            if (damageable != null)
            {
                damageable.DamageToPlayerHealth(_groundSlamDamage);
                Debug.Log("working");
                boss.StateMachine.ChangeState(boss.ChaseState);
            }
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
    }
}
