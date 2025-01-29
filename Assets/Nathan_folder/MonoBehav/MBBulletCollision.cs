using UnityEngine;

public class MBBulletCollision : MonoBehaviour
{
    public MBBulletPooling bulletPooling;
    public float bulletDamage;
    public float bulletPenetration;
    public float bulletKnockback;

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
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if(damageable != null)
        {
            damageable.Damage(bulletDamage);
            Debug.Log(bulletDamage);
        }

        if (bulletPooling != null)
        {
            bulletPooling.AddToPool(this.gameObject);
        }
        
    }
}
