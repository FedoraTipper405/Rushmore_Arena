using UnityEngine;

public class EnemyChaseSOBase : ScriptableObject
{
    protected BaseEnemy baseEnemy;
    protected Transform transform;
    protected GameObject gameObject;
    protected Transform playerTransform;
    public virtual void Initialize(GameObject gameObject, BaseEnemy baseEnemy)
    {
        this.gameObject = gameObject;
        transform = gameObject.transform;
        this.baseEnemy = baseEnemy;

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public virtual void DoEnterLogic() { }
    public virtual void DoExitLogic() { }
    public virtual void DoFrameUpdateLogic() { }
}
