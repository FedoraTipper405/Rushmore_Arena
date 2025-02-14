using UnityEngine;

public class BossCollisionHit : MonoBehaviour
{
    public GameObject PlayerTarget { get; set; }
    private Boss _boss;

    private void Awake()
    {
        PlayerTarget = GameObject.FindGameObjectWithTag("Player");
        _boss = GetComponentInParent<Boss>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageablePlayer damageable = collision.gameObject.GetComponent<IDamageablePlayer>();
        if (damageable != null)
        {
            damageable.DamageToPlayerHealth(_boss.BossStatSO.BossMeleeDamage);
        }
    }
}
