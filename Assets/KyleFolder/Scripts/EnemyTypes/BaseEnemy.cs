using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class BaseEnemy : MonoBehaviour, IDamageable, IEnemyMoveable, ITriggerCheckable
{
    public SOEnemyStats EnemyStatSO;
    public float MaxHealth => EnemyStatSO.EnemyMaxHealth;
    public float DamageAmount => EnemyStatSO.EnemyDamage;

    [HideInInspector] public float ChargeSpeed;
    [HideInInspector] public float MovementSpeed;
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

    public SpriteRenderer HitColor;

    public MBWaveManager waveManager;

    [HideInInspector] public bool IsKnockedBack;

    private bool IsOnFire;

    public void Awake()
    {
        EnemyMovementBaseInstance = Instantiate(EnemyMovementBase);

        EnemyChaseBaseInstance = Instantiate(EnemyChaseBase);
        
        StateMachine = new EnemyStateMachine();
        
        StateMovement = new EnemyMovementState(this, StateMachine);

        StateChase = new EnemyChaseState(this, StateMachine);

        IsKnockedBack = false;
        
        IsOnFire = true;

        MovementSpeed = EnemyStatSO.EnemyMovementSpeed;

        ChargeSpeed = EnemyStatSO.EnemyChargeSpeed;
    }

    private void Start()
    {
        CurrentHealth = MaxHealth;

        RB = GetComponent<Rigidbody2D>();

        EnemyMovementBaseInstance.Initialize(gameObject, this);

        EnemyChaseBaseInstance.Initialize(gameObject, this);

        StateMachine.Initialize(StateMovement);
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentEnemyState.FrameUpdate();
    }

    public void Damage(float damageAmount)
    {
        CurrentHealth -= damageAmount;
        StartCoroutine(HitColorFlash(new Color(0.68f, 0.68f, 0.68f)));
        if (CurrentHealth <= 0f)
        {
            Die();
        }
    }

    IEnumerator HitColorFlash(Color flashColor)
    {
        Color lastColor;
        if (HitColor.color == flashColor)
        {
            lastColor = new Color(1, 1, 1);
        }
        else
        {
            lastColor = HitColor.color;
        }
        
        HitColor.color = flashColor;
        yield return new WaitForSeconds(0.1f);
        HitColor.color = lastColor;
    }

    public void KnockBack(Transform bulletTransform, float knockBackForce)
    {
        IsKnockedBack = true;
        Vector2 direction = (transform.position - bulletTransform.position).normalized;
        RB.linearVelocity = direction * knockBackForce;
        StartCoroutine(KnockBackTimer());
    }
    IEnumerator KnockBackTimer()
    {
        yield return new WaitForSeconds(0.5f);
        IsKnockedBack = false;
    }
    public void DamageOverTime(float damageOverTimeAmount, float damageOverTimeTicks)
    {
        StartCoroutine(Burn(damageOverTimeAmount, damageOverTimeTicks));
    }

    IEnumerator Burn(float damageOverTimeAmount, float damageOverTimeTicks)
    {
        if (IsOnFire == true)
        {
            while (damageOverTimeTicks > 0f)
            {
                IsOnFire = false;
                CurrentHealth -= damageOverTimeAmount;
                yield return new WaitForSeconds(1f);
                StartCoroutine(HitColorFlash(new Color(1, 0.5f, 0)));
                damageOverTimeTicks--;
                if (CurrentHealth <= 0f)
                {
                    Die();
                }
            }
            IsOnFire = true;
        }
    }
    public void Freeze(float speedReductionAmount, float freezeTimer)
    {
        StartCoroutine(FreezeTimer(speedReductionAmount, freezeTimer));
    }

    IEnumerator FreezeTimer(float speedReductionAmount, float freezeTimer)
    {
        HitColor.color = new Color(0.05f,0.8f,0.95f);
        MovementSpeed *= speedReductionAmount;
        yield return new WaitForSeconds(freezeTimer);
        MovementSpeed /= speedReductionAmount;
        HitColor.color = Color.white;
    }

    public void Die()
    { 
       Destroy(gameObject);
    }
    public void OnDestroy()
    {
        waveManager.EnemyKilled();
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
