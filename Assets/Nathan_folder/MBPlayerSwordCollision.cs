using UnityEngine;

public class MBPlayerSwordCollision : MonoBehaviour
{
    [SerializeField] private MBJeffyPC JeffyPc;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.Damage(JeffyPc.attackDamage * Mathf.Clamp(JeffyPc.attackDamageUpgrade, 0.05f, 10));
            Debug.Log(JeffyPc.attackDamage * Mathf.Clamp(JeffyPc.attackDamageUpgrade,0.05f, 10));
        }
    }
}
