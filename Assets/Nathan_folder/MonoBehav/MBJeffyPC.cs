using System.Collections;
using UnityEngine;

public class MBJeffyPC : MBBasePlayerController
{
    [SerializeField] GameObject LeftAttackCollider;
    [SerializeField] GameObject RightAttackCollider;
    [SerializeField] GameObject UpAttackCollider;
    [SerializeField] GameObject DownAttackCollider;
    
    [SerializeField] GameObject LeftUpAttackCollider;
    [SerializeField] GameObject LeftDownAttackCollider;
    [SerializeField] GameObject RightUpAttackCollider;
    [SerializeField] GameObject RightDownAttackCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveSpeed = StatSO.moveSpeed;
        attackDamage = StatSO.attackDamage;
        attackSpeed = StatSO.attackSpeed;
        attackRange = StatSO.attackRange;
        health = StatSO.health;
        maxHealth = StatSO.health;
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
        //right attack
        if (currentShootDirection.x > 0)
        {
            if(currentShootDirection.y == 0)
            {
                StartCoroutine(AttackColliderOn(RightAttackCollider));
            }
            else if(currentShootDirection.y > 0)
            {
                StartCoroutine(AttackColliderOn(RightUpAttackCollider));
            }
            else
            {
                StartCoroutine(AttackColliderOn(RightDownAttackCollider));
            }
        } 
        //left attack
        else if(currentShootDirection.x < 0)
        {
            if (currentShootDirection.y == 0)
            {
                StartCoroutine(AttackColliderOn(LeftAttackCollider));
            }
            else if (currentShootDirection.y > 0)
            {
                StartCoroutine(AttackColliderOn(LeftUpAttackCollider));
            }
            else
            {
                StartCoroutine(AttackColliderOn(LeftDownAttackCollider));
            }
        }
        //up or down
        else
        {
            if(currentShootDirection.y > 0)
            {
                StartCoroutine(AttackColliderOn(UpAttackCollider));
            }
            else
            {
                StartCoroutine(AttackColliderOn(DownAttackCollider));
            }
        }
    }
    IEnumerator AttackColliderOn(GameObject directionalCollider)
    {
        directionalCollider.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        directionalCollider.SetActive(false);
    }
        // Update is called once per frame
        void Update()
    {
        
    }
}
