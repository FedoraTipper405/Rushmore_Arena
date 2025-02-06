using UnityEngine;

public class BossState
{
    protected Boss boss;
    protected BossStateMachine bossStateMachine;
    protected Transform playerTransform;

    public BossState(Boss boss, BossStateMachine bossStateMachine)
    {
        this.boss = boss;
        this.bossStateMachine = bossStateMachine;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public virtual void EnterState() { }
    public virtual void ExitState() { }
    public virtual void FrameUpdate() { }

}
