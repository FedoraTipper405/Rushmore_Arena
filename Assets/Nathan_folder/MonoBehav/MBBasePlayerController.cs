using UnityEngine;

public class MBBasePlayerController : MonoBehaviour, IDamageablePlayer
{
    [SerializeField] public GameObject bulletPrefab;
    public bool isAttacking = false;
    private float atkCooldown = 0;

    private float movementOnX;
    private float movementOnY;
    public Vector3 lastMoveDirection = new Vector3(1f,0f,0f);
    public Vector3 currentShootDirection = new Vector3(1f,0f,0f);
    public SOPlayerCharacters StatSO;
    public float moveSpeed;
    public float attackDamage;
    public float attackSpeed;
    public float health;
    public float attackRange;
    public bool isRangedAttacker;
    public int projectileAmount;
    public float projectileSpeed;
    public float projectileSize;
    public float knockBack;
    public int penetration;
    public float projectileSpread;


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
        }
        movementOnY = moveInput.y; 
        movementOnX = moveInput.x; 
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
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(lastMoveDirection.x + " " + lastMoveDirection.z + " " + lastMoveDirection.y);
    }
    void FixedUpdate()
    {
        this.transform.position += (new Vector3(movementOnX, movementOnY,0 ) * moveSpeed) / 10;
        if (isAttacking && atkCooldown <= 0)
        {
            Attack();
            atkCooldown = attackSpeed;
        }

        if (atkCooldown > 0)
        {
            atkCooldown -= Time.deltaTime;
        }
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
        Debug.Log("Man I'm dead");
    }
}
