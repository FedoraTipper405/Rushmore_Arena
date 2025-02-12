using System.Collections;
using UnityEngine;

public class BossGroundSlam : BossState
{
    public BossGroundSlam(Boss boss, BossStateMachine bossStateMachine) : base(boss, bossStateMachine) { }

    public override void EnterState()
    {
        base.EnterState();
        Collider2D[] colliders = Physics2D.OverlapCircleAll(boss.transform.position, 4f);
        foreach(Collider2D hit in colliders)
        {
            IDamageablePlayer damageable = hit.gameObject.GetComponent<IDamageablePlayer>();
            if (damageable != null)
            {
                damageable.DamageToPlayerHealth(20f);
                Debug.Log("working");
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
