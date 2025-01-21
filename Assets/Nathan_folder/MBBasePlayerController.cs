using UnityEngine;

public class MBBasePlayerController : MonoBehaviour
{
    [SerializeField] public GameObject bulletPrefab;
    [SerializeField] private float playerMoveSpeed;
    private float playerAtkRate = .5f;
    public bool isAttacking = false;
    private float atkCooldown = 0;

    private float movementOnX;
    private float movementOnY;
    public Vector3 lastMoveDirection = new Vector3(1f,0f,0f);
    public Vector3 currentShootDirection = new Vector3(1f,0f,0f);
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

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
        if (inputState == true)
        {
            currentShootDirection = lastMoveDirection;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(lastMoveDirection.x + " " + lastMoveDirection.z + " " + lastMoveDirection.y);
    }
    void FixedUpdate()
    {
        this.transform.position += (new Vector3(movementOnX, movementOnY,0 ) * playerMoveSpeed) / 10;
        if (isAttacking && atkCooldown <= 0)
        {
            Attack();
            atkCooldown = playerAtkRate;
        }

        if (atkCooldown > 0)
        {
            atkCooldown -= Time.deltaTime;
        }
    }
}
