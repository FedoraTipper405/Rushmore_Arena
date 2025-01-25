using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour, IDamageable, IEnemyMoveable, ITriggerCheckable
{
    public float MaxHealth { get; set; } = 100f;
    public float CurrentHealth { get; set; }
    public Rigidbody2D RB { get; set; }
    public bool IsFacingRight { get; set; }

    public EnemyStateMachine StateMachine { get; set; } 
    public EnemyMovementState StateMovement { get; set; }
    public EnemyChaseState StateChase { get; set; }
    public EnemyAttackState StateAttack { get; set; }
    
    [SerializeField] private EnemyMovementSOBase EnemyMovementBase;

    [SerializeField] private EnemyChaseSOBase EnemyChaseBase;

    [SerializeField] private EnemyAttackSOBase EnemyAttackBase;

    public EnemyMovementSOBase EnemyMovementBaseInstance { get; set; }
    public EnemyChaseSOBase EnemyChaseBaseInstance { get; set; }
    public EnemyAttackSOBase EnemyAttackBaseInstance { get; set; }
    public bool IsInRangeToChase { get; set; }
    public bool IsInRangeOfAttack { get; set; }

    public void Awake()
    {
        EnemyMovementBaseInstance = Instantiate(EnemyMovementBase);

        EnemyChaseBaseInstance = Instantiate(EnemyChaseBase);

        EnemyAttackBaseInstance = Instantiate(EnemyAttackBase);
        
        StateMachine = new EnemyStateMachine();
        
        StateMovement = new EnemyMovementState(this, StateMachine);

        StateChase = new EnemyChaseState(this, StateMachine);

        StateAttack = new EnemyAttackState(this, StateMachine);
    }

    private void Start()
    {
        CurrentHealth = MaxHealth;

        RB = GetComponent<Rigidbody2D>();

        EnemyMovementBaseInstance.Initialize(gameObject, this);

        EnemyChaseBaseInstance.Initialize(gameObject, this);

        EnemyAttackBaseInstance.Initialize(gameObject, this);

        StateMachine.Initialize(StateMovement);
    }

    private void Update()
    {
        StateMachine.CurrentEnemyState.FrameUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentEnemyState.PhysicsUpdate();
    }

    public void Damage(float damageAmount)
    {
        CurrentHealth -= damageAmount;

        if (CurrentHealth <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
       Destroy(gameObject);
    }

    public void MoveEnemy(Vector2 velocity)
    {
        RB.linearVelocity = velocity;
        CheckFacing(velocity);
    }

    public void CheckFacing(Vector2 velocity)
    {
        if(IsFacingRight && velocity.x < 0f)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            IsFacingRight = !IsFacingRight;
        }

        else if (!IsFacingRight && velocity.x > 0f)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            IsFacingRight = !IsFacingRight;
        }
    }

    private void AnimationTriggerEvent(AnimationTriggerType triggerType)
    {
        StateMachine.CurrentEnemyState.AnimationTriggerEvent(triggerType);
    }

    public void ChasePlayer(bool isInRangeToChase)
    {
        IsInRangeToChase = isInRangeToChase;
    }

    public void AttackPlayer(bool isInRangeOfAttack)
    {
        IsInRangeOfAttack = isInRangeOfAttack;
    }

    public enum AnimationTriggerType
    {
        Movement,
        Attack
    }
}
