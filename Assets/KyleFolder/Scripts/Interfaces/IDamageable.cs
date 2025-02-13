using UnityEngine;

public interface IDamageable
{
    void Damage(float damageAmount);
    void Die();
    void DamageOverTime(float damageOverTimeAmount, float damageOverTimer);
    void KnockBack(Transform bulletTransform, float knockBackForce);
    void Freeze(float speedReductionAmount, float freezeTimer);
}
