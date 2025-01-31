using UnityEngine;

public class MBBulletCollision : MonoBehaviour
{
    public MBBulletPooling bulletPooling;
    public float bulletDamage;
    public float bulletPenetration;
    public float bulletKnockback;
    public bool doesMoreDamageCloseRange = false;
    [SerializeField] MBBulletMovement bulletMovement;
    [SerializeField] private float closeRangeDistance = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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

        if (bulletPooling != null && bulletPenetration <= 0)
        {
            bulletMovement = null;
            bulletPooling.AddToPool(this.gameObject);
        }
        
    }
}
