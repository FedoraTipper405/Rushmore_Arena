using UnityEngine;

public class MBWashingtonPC : MBBasePlayerController
{
    [SerializeField] private MBBulletPooling bulletPoolScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         moveSpeed = StatSO.moveSpeed;
         attackDamage = StatSO.attackDamage;
         attackSpeed = StatSO.attackSpeed;
         attackRange = StatSO.attackRange;
        health = StatSO.health;
         isRangedAttacker = StatSO.isRangedAttacker;
         projectileAmount = StatSO.projectileAmount;
         projectileSpeed = StatSO.projectileSpeed;
         projectileSize = StatSO.projectileSize;
         knockBack = StatSO.knockBack;
         penetration = StatSO.penetration;
    }
    
    public override void Attack()
    {
        GameObject lastBullet = null;
        if (bulletPoolScript != null && bulletPoolScript.Bulletpool.Count > 0)
        {
            lastBullet = bulletPoolScript.GetFromPool();
            lastBullet.transform.position = this.transform.position;

        }
        else if(bulletPoolScript != null && bulletPoolScript.Bulletpool.Count <= 0)
        {
          lastBullet = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);
        }
        MBBulletCollision tempBulletCollision = lastBullet.GetComponent<MBBulletCollision>();
        MBBulletMovement tempBulletMovement = lastBullet.GetComponent<MBBulletMovement>();
        tempBulletCollision.bulletPooling = bulletPoolScript;
        tempBulletCollision.bulletDamage = attackDamage;
       
        tempBulletCollision.bulletPenetration = penetration;
        tempBulletCollision.bulletKnockback = knockBack;
        tempBulletMovement.bulletRange = attackRange;
        tempBulletMovement.bulletPooling = bulletPoolScript;
        tempBulletMovement.distanceTraveled = 0;
        tempBulletMovement.moveSpeed = projectileSpeed;
        tempBulletMovement.moveDirection = currentShootDirection; 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
