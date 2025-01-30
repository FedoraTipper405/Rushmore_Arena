using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour, IDamageable, IEnemyMoveable, ITriggerCheckable
{
    [field: SerializeField] public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }
    public Rigidbody2D RB { get; set; }
    public bool IsFacingRight { get; set; }

    public EnemyStateMachine StateMachine { get; set; } 
    public EnemyMovementState StateMovement { get; set; }
    public EnemyChaseState StateChase { get; set; }
    
    [SerializeField] private EnemyMovementSOBase EnemyMovementBase;

    [SerializeField] private EnemyChaseSOBase EnemyChaseBase;

    public EnemyMovementSOBase EnemyMovementBaseInstance { get; set; }
    public EnemyChaseSOBase EnemyChaseBaseInstance { get; set; }
    public bool IsInRangeToChase { get; set; }
    public bool ObjectInWay { get; set; }
    
    public Animator EnemyAnimator;

    public void Awake()
    {
        EnemyMovementBaseInstance = Instantiate(EnemyMovementBase);

        EnemyChaseBaseInstance = Instantiate(EnemyChaseBase);
        
        StateMachine = new EnemyStateMachine();
        
        StateMovement = new EnemyMovementState(this, StateMachine);

        StateChase = new EnemyChaseState(this, StateMachine);
    }

    private void Start()
    {
        CurrentHealth = MaxHealth;

        RB = GetComponent<Rigidbody2D>();

        EnemyMovementBaseInstance.Initialize(gameObject, this);

        EnemyChaseBaseInstance.Initialize(gameObject, this);

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

    public void ChasePlayer(bool isInRangeToChase)
    {
        IsInRangeToChase = isInRangeToChase;
    }

    public void ObjectInTheWay(bool objectInWay)
    {
        ObjectInWay = objectInWay;
    }
}
