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
            damageable.Damage(JeffyPc.attackDamage * JeffyPc.attackDamageUpgrade);
            Debug.Log(JeffyPc.attackDamage * JeffyPc.attackDamageUpgrade);
        }
    }
}
