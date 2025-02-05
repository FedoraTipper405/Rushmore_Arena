using UnityEngine;

public class MBBulletCollision : MonoBehaviour
{
    public MBBulletPooling bulletPooling;
    public float bulletDamage;
    public float bulletPenetration;
    public float bulletKnockback;
    public float bulletDamageOverTimeAmount;
    public float bulletDamageOverTimeTicks;
    public bool doesMoreDamageCloseRange = false;
    [SerializeField] MBBulletMovement bulletMovement;
    [SerializeField] private float closeRangeDistance = 2;
    private Transform bulletTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bulletTransform = GetComponent<Transform>();
    }
    public void OnEnable()
    {
        bulletMovement = this.gameObject.GetComponent<MBBulletMovement>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        bulletPenetration--;
        if(bulletMovement != null)
        {
            if (bulletMovement.distanceTraveled < closeRangeDistance && doesMoreDamageCloseRange)
            {
                Debug.Log("Double Damage");
                bulletDamage *= 2;
            }
        }
        
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if(damageable != null)
        {
            damageable.Damage(bulletDamage);
            Debug.Log(bulletDamage);
        }
        
        IDamageable damageableOverTime = collision.gameObject.GetComponent<IDamageable>();
        if (damageableOverTime != null)
        {
            damageableOverTime.DamageOverTime(bulletDamageOverTimeAmount, bulletDamageOverTimeTicks);
        }

        IDamageable knockBack = collision.gameObject.GetComponent<IDamageable>();
        if (knockBack != null)
        {
            knockBack.KnockBack(bulletTransform, bulletKnockback);
        }

        if (bulletPooling != null && bulletPenetration <= 0)
        {
            bulletMovement = null;
            bulletPooling.AddToPool(this.gameObject);
        }
        
    }
}
