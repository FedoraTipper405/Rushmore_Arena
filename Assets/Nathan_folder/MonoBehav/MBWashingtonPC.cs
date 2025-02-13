using System;
using UnityEngine;

public class MBWashingtonPC : MBBasePlayerController
{
    [SerializeField] private MBBulletPooling bulletPoolScript;

    [SerializeField] GameObject bulletSpawnLeft;
    [SerializeField] GameObject bulletSpawnRight;
    [SerializeField] GameObject bulletSpawnUp;
    [SerializeField] GameObject bulletSpawnDown;
    private GameObject currentBulletSpawn;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentBulletSpawn = bulletSpawnRight;
        moveSpeed = StatSO.moveSpeed;
        attackDamage = StatSO.attackDamage;
        attackSpeed = StatSO.attackSpeed;
        attackRange = StatSO.attackRange;
        health = StatSO.health;
        baseMaxHealth = StatSO.health;
        isRangedAttacker = StatSO.isRangedAttacker;
        projectileAmount = StatSO.projectileAmount;
        projectileSpeed = StatSO.projectileSpeed;
        projectileSize = StatSO.projectileSize;
        knockBack = StatSO.knockBack;
        penetration = StatSO.penetration;
        projectileSpread = StatSO.spread;
    }

    public override void Attack()
    {
        Debug.Log("here");
        if (Mathf.Abs(currentShootDirection.x) >= Mathf.Abs(currentShootDirection.y))
        {
            if (currentShootDirection.x > 0)
            {
                currentBulletSpawn = bulletSpawnRight;
            }
            else
            {
                currentBulletSpawn = bulletSpawnLeft;
            }
        }
        else
        {
            if (currentShootDirection.y > 0)
            {
                currentBulletSpawn = bulletSpawnUp;
            }
            else
            {
                currentBulletSpawn = bulletSpawnDown;
            }
        }
        GameObject lastBullet = null;
        if (bulletPoolScript != null && bulletPoolScript.Bulletpool.Count > 0)
        {
            lastBullet = bulletPoolScript.GetFromPool();
            lastBullet.transform.position = currentBulletSpawn.transform.position;

        }
        else if (bulletPoolScript != null && bulletPoolScript.Bulletpool.Count <= 0)
        {
            lastBullet = Instantiate(bulletPrefab, currentBulletSpawn.transform.position, Quaternion.identity);
        }
        MBBulletCollision tempBulletCollision = lastBullet.GetComponent<MBBulletCollision>();
        MBBulletMovement tempBulletMovement = lastBullet.GetComponent<MBBulletMovement>();
        lastBullet.transform.localScale = new Vector3(projectileSize * Mathf.Clamp(projectileSizeUpgrade, 0.1f, 10), projectileSize * Mathf.Clamp(projectileSizeUpgrade, 0.1f, 10), 0);
        tempBulletCollision.bulletPooling = bulletPoolScript;
        tempBulletCollision.bulletDamage = (attackDamage * Mathf.Clamp(attackDamageUpgrade, 0.1f, 10)) / Mathf.Clamp(projectileAmount, 1, 100);

        //unique to washington
        tempBulletCollision.doesMoreDamageCloseRange = hasUniqueCardOne;

        tempBulletCollision.bulletPenetration = penetration;
        tempBulletCollision.bulletKnockback = knockBack * Mathf.Clamp(knockbackUpgrade, 0.1f, 10);
        tempBulletMovement.bulletRange = attackRange * Mathf.Clamp(attackRangeUpgrade, 0.1f, 10);
        tempBulletMovement.bulletPooling = bulletPoolScript;
        tempBulletMovement.distanceTraveled = 0;
        tempBulletMovement.moveSpeed = projectileSpeed * Mathf.Clamp(projectileSpeedUpgrade, 0.1f, 10);
        tempBulletMovement.moveDirection = currentShootDirection;
        if (projectileAmount > 1)
        {
            for (int i = 0; i < projectileAmount - 1; i++)
            {
                Vector3 shotgunShootDirection = new Vector3(0, 0, 0);
                if (Mathf.Abs(currentShootDirection.x) == Mathf.Abs(currentShootDirection.y))
                {
                    float negativeChangerX = 1;
                    float negativeChangerY = 1;
                    if (currentShootDirection.x < 0)
                    {
                        negativeChangerX = -1;
                    }
                    if (currentShootDirection.y < 0)
                    {
                        negativeChangerY = -1;
                    }
                    if (i % 2 == 0)
                    {
                        if (currentShootDirection.x > 0)
                        {
                            shotgunShootDirection.x = currentShootDirection.x - UnityEngine.Random.Range(0, Math.Clamp(projectileSpread * projectileSpreadUpgrade, 0, 0.7f));
                        }
                        else
                        {
                            shotgunShootDirection.x = currentShootDirection.x + UnityEngine.Random.Range(0, Math.Clamp(projectileSpread * projectileSpreadUpgrade, 0, 0.7f));
                        }

                        shotgunShootDirection.y = Mathf.Sqrt(1 - MathF.Pow(shotgunShootDirection.x, 2)) * negativeChangerY;
                    }
                    else
                    {
                        if (currentShootDirection.y > 0)
                        {
                            shotgunShootDirection.y = currentShootDirection.y - UnityEngine.Random.Range(0, Math.Clamp(projectileSpread * projectileSpreadUpgrade, 0, 0.7f));
                        }
                        else
                        {
                            shotgunShootDirection.y = currentShootDirection.y + UnityEngine.Random.Range(0, Math.Clamp(projectileSpread * projectileSpreadUpgrade, 0, 0.7f));
                        }
                        shotgunShootDirection.x = Mathf.Sqrt(1 - MathF.Pow(shotgunShootDirection.y, 2)) * negativeChangerX;
                    }
                }
                else if (Mathf.Abs(currentShootDirection.x) > Mathf.Abs(currentShootDirection.y))
                {
                    if (i % 2 == 0)
                    {
                        shotgunShootDirection.y = currentShootDirection.y - UnityEngine.Random.Range(0, Math.Clamp(projectileSpread * projectileSpreadUpgrade, 0, 0.7f));
                        shotgunShootDirection.x = Mathf.Sqrt(1 - MathF.Pow(shotgunShootDirection.y, 2));
                    }
                    else
                    {
                        shotgunShootDirection.y = currentShootDirection.y + UnityEngine.Random.Range(0, Math.Clamp(projectileSpread * projectileSpreadUpgrade, 0, 0.7f));
                        shotgunShootDirection.x = Mathf.Sqrt(1 - MathF.Pow(shotgunShootDirection.y, 2));
                    }
                    if (currentShootDirection.x < 0)
                    {
                        shotgunShootDirection.x *= -1;
                    }
                }
                else
                {
                    if (i % 2 == 0)
                    {
                        shotgunShootDirection.x = currentShootDirection.x - UnityEngine.Random.Range(0, Math.Clamp(projectileSpread, 0, 0.7f));
                        shotgunShootDirection.y = Mathf.Sqrt(1 - MathF.Pow(shotgunShootDirection.y, 2));
                    }
                    else
                    {
                        shotgunShootDirection.x = currentShootDirection.x + UnityEngine.Random.Range(0, Math.Clamp(projectileSpread, 0, 0.7f));
                        shotgunShootDirection.y = Mathf.Sqrt(1 - MathF.Pow(shotgunShootDirection.x, 2));
                    }
                    if (currentShootDirection.y < 0)
                    {
                        shotgunShootDirection.y *= -1;
                    }
                }
                if (bulletPoolScript != null && bulletPoolScript.Bulletpool.Count > 0)
                {
                    lastBullet = bulletPoolScript.GetFromPool();
                    lastBullet.transform.position = currentBulletSpawn.transform.position;

                }
                else if (bulletPoolScript != null && bulletPoolScript.Bulletpool.Count <= 0)
                {
                    lastBullet = Instantiate(bulletPrefab, currentBulletSpawn.transform.position, Quaternion.identity);
                }
                tempBulletCollision = lastBullet.GetComponent<MBBulletCollision>();
                tempBulletMovement = lastBullet.GetComponent<MBBulletMovement>();
                lastBullet.transform.localScale = new Vector3(projectileSize * Mathf.Clamp(projectileSizeUpgrade, 0.1f, 10), projectileSize * Mathf.Clamp(projectileSizeUpgrade, 0.1f, 10), 0);
                tempBulletCollision.bulletPooling = bulletPoolScript;
                tempBulletCollision.bulletDamage = (attackDamage * Mathf.Clamp(attackDamageUpgrade, 0.1f, 10)) / Mathf.Clamp(projectileAmount, 1, 100);

                //unique to washington
                tempBulletCollision.doesMoreDamageCloseRange = hasUniqueCardOne;

                tempBulletCollision.bulletPenetration = penetration;
                tempBulletCollision.bulletKnockback = knockBack * Mathf.Clamp(knockbackUpgrade, 0.1f, 10);
                tempBulletMovement.bulletRange = attackRange * Mathf.Clamp(attackRangeUpgrade, 0.1f, 10);
                tempBulletMovement.bulletPooling = bulletPoolScript;
                tempBulletMovement.distanceTraveled = 0;
                tempBulletMovement.moveSpeed = projectileSpeed * Mathf.Clamp(projectileSpeedUpgrade, 0.1f, 10);
                tempBulletMovement.moveDirection = shotgunShootDirection;
            }

        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
