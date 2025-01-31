using UnityEngine;
using UnityEngine.SceneManagement;

public class MBBasePlayerController : MonoBehaviour, IDamageablePlayer
{
    [SerializeField] public GameObject bulletPrefab;
    public bool isAttacking = false;
    public bool isUpgrading = false;
    private float atkCooldown = 0;

    private float movementOnX;
    private float movementOnY;
    public Vector3 lastMoveDirection = new Vector3(1f,0f,0f);
    public Vector3 currentShootDirection = new Vector3(1f,0f,0f);

    public SOPlayerCharacters StatSO;
    public float moveSpeed;
    public float attackDamage;
    public float attackSpeed;
    public float maxHealth;
    public float health;
    public float attackRange;
    public bool isRangedAttacker;
    public int projectileAmount;
    public float projectileSpeed;
    public float projectileSize;
    public float knockBack;
    public int penetration;
    public float projectileSpread;
    public bool hasUniqueCardOne = false;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator _animator;

    [SerializeField] private Transform middleOfArena;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    //handles movement
    public void HandleMovement(Vector2 moveInput)
    {
        if (moveInput.x != 0 || moveInput.y != 0)
        {
            lastMoveDirection.x = moveInput.x;
            lastMoveDirection.y = moveInput.y;
            SwitchAnimationForPlayer();
        }
        movementOnY = moveInput.y; 
        movementOnX = moveInput.x; 
        if(moveInput.x == 0 && moveInput.y == 0)
        {
            StopPlayerAnimation();
        }
    }
     virtual public void Attack()
    {
       
    }
    virtual public void HandleAttack(bool inputState)
    {
        isAttacking = inputState;
        if (inputState == true && lastMoveDirection != new Vector3 (0,0,0))
        {
            currentShootDirection = lastMoveDirection;
        }
        else
        {
            currentShootDirection = new Vector3(1,0,0);
        }
        if(inputState == false)
        {
            SwitchAnimationForPlayer();
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
    void StopPlayerAnimation()
    {

    }
    void SwitchAnimationForPlayer()
    {
        if(Mathf.Abs(lastMoveDirection.x) >= Mathf.Abs(lastMoveDirection.y) && isAttacking == false)
        {
            //HorizontalAnimations
            if (lastMoveDirection.x > 0)
            {
                //moving right/diaganol right
                spriteRenderer.flipX = false;
                _animator.SetBool("IsGoingUp", false);
                _animator.SetBool("IsGoingDown", false);

            }
            else if (lastMoveDirection.x < 0)
            {
                //moving left/diaganol left
                spriteRenderer.flipX = true;
                _animator.SetBool("IsGoingUp", false);
                _animator.SetBool("IsGoingDown", false);

            }
        }
        else if (isAttacking == false)
        {
            //verticalAnimations
            if (lastMoveDirection.y > 0)
            {
                //moving Up
                _animator.SetBool("IsGoingUp", true);
                _animator.SetBool("IsGoingDown", false);
            }
            else if (lastMoveDirection.y < 0)
            {
                //moving Down
                _animator.SetBool("IsGoingUp", false);
                _animator.SetBool("IsGoingDown", true);
            }
        }

    }
    void FixedUpdate()
    {
       if(isUpgrading == false)
        {
            this.transform.position += (new Vector3(movementOnX, movementOnY, 0) * Mathf.Clamp(moveSpeed, 0, 20)) / 10;
        }
       
        if (isAttacking && atkCooldown <= 0 && isUpgrading == false)
        {
            Attack();
            atkCooldown = attackSpeed;
        }

        if (atkCooldown > 0)
        {
            atkCooldown -= Time.deltaTime;
        }
    }
    public void ResetPlayerPerRound()
    {
        this.transform.position = middleOfArena.position;
        health = maxHealth;
    }
    public void DamageToPlayerHealth(float damageAmount)
    {
        health -= damageAmount;

        if(health < 0)
        {
            PlayerDies();
        }
    }

    public void PlayerDies()
    {
        SceneManager.LoadScene("RushmoreMainMenu");
        Debug.Log("Man I'm dead");
    }
}
