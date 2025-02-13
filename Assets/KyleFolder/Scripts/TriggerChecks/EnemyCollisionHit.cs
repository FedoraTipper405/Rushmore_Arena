using UnityEngine;

public class EnemyCollisionHit : MonoBehaviour
{
    public GameObject PlayerTarget { get; set; }
    private BaseEnemy _baseEnemy;

    private void Awake()
    {
        PlayerTarget = GameObject.FindGameObjectWithTag("Player");
        _baseEnemy = GetComponentInParent<BaseEnemy>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageablePlayer damageable = collision.gameObject.GetComponent<IDamageablePlayer>();
        if (damageable != null)
        {
            damageable.DamageToPlayerHealth(_baseEnemy.DamageAmount);
        }
    }
}
