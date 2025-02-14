using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boss : MonoBehaviour, IDamageable, IEnemyMoveable
{
    public SOBossStats BossStatSO;
    public float MaxHealth => BossStatSO.BossMaxHealth;
    public float CurrentHealth { get; set; }
    public Rigidbody2D RB { get; set; }
    public bool IsFacingRight { get; set; }

    #region State Machine Variables
    public BossStateMachine StateMachine { get; set; }
    public BossChase ChaseState { get; set; }
    public BossCharge ChargeState { get; set; }
    public BossArrowSpiral ArrowSpiralState { get; set; }
    public BossArrowBurst ArrowBurstState { get; set; }
    public BossGroundSlam GroundSlamState { get; set; }
    # endregion

    public GameObject ArrowPrefab => BossStatSO.ArrowPrefab;
    
    public Animator BossAnimator;

    public GameObject GroundSlamIndicator;

    [SerializeField] Slider healthBar;
    [SerializeField] Transform healthBarTransform;
    private float healthBarBaseScale;

    private void Awake()
    {
        StateMachine = new BossStateMachine();
        ChaseState = new BossChase(this, StateMachine);
        ChargeState = new BossCharge(this, StateMachine);
        ArrowSpiralState = new BossArrowSpiral(this, StateMachine);
        ArrowBurstState = new BossArrowBurst(this, StateMachine);
        GroundSlamState = new BossGroundSlam(this, StateMachine);
        healthBarBaseScale = healthBarTransform.localScale.x;
    }
    private void Start()
    {
        CurrentHealth = MaxHealth;
        healthBar.maxValue = MaxHealth;
        RB = GetComponent<Rigidbody2D>();

        StateMachine.Initialize(ChaseState);
    }

    public void Damage(float damageAmount)
    {
        CurrentHealth -= damageAmount;
        healthBar.value = CurrentHealth;
        if (CurrentHealth <= 0f)
        {
            Die();
        }
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentBossState.FrameUpdate();
    }

    public void Die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("VictoryScene");
    }
    public void DamageOverTime(float damageOverTimeAmount, float damageOverTimer)
    {

    }

    public void KnockBack(Transform bulletTransform, float knockBackForce)
    {

    }
    public void Freeze(float speedReductionAmount, float freezeTimer)
    {

    }

    public void MoveEnemy(Vector2 velocity)
    {
        RB.linearVelocity = velocity;
        CheckFacing(velocity);
    }
    public void CheckFacing(Vector2 velocity)
    {
        if (IsFacingRight && velocity.x < 0f)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            IsFacingRight = !IsFacingRight;
            healthBarTransform.localScale = new Vector3(healthBarBaseScale, healthBarTransform.localScale.y, healthBarTransform.localScale.z);
        }

        else if (!IsFacingRight && velocity.x > 0f)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
            healthBarTransform.localScale = new Vector3(healthBarBaseScale * -1, healthBarTransform.localScale.y, healthBarTransform.localScale.z);
            transform.rotation = Quaternion.Euler(rotator);
            IsFacingRight = !IsFacingRight;
        }
    }
}
