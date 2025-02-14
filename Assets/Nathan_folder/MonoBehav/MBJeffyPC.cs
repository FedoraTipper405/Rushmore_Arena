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

    [SerializeField] GameObject FullAttackCircle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
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
        base.Start();
    }
    public override void Attack()
    {
        //right attack
        AudioManager.PlaySound(1);
        if (hasUniqueCardOne)
        {
            StartCoroutine(AttackColliderOn(FullAttackCircle));
        }
        else
        {
            if (currentShootDirection.x > 0)
            {
                if (currentShootDirection.y == 0)
                {
                    StartCoroutine(AttackColliderOn(RightAttackCollider));
                    _animator.SetTrigger("AttackSide");
                }
                else if (currentShootDirection.y > 0)
                {
                    StartCoroutine(AttackColliderOn(RightUpAttackCollider));
                    _animator.SetTrigger("AttackSide");
                }
                else
                {
                    StartCoroutine(AttackColliderOn(RightDownAttackCollider));
                    _animator.SetTrigger("AttackSide");
                }
            }
            //left attack
            else if (currentShootDirection.x < 0)
            {
                if (currentShootDirection.y == 0)
                {
                    StartCoroutine(AttackColliderOn(LeftAttackCollider));
                    _animator.SetTrigger("AttackSide");
                }
                else if (currentShootDirection.y > 0)
                {
                    StartCoroutine(AttackColliderOn(LeftUpAttackCollider));
                    _animator.SetTrigger("AttackSide");
                }
                else
                {
                    StartCoroutine(AttackColliderOn(LeftDownAttackCollider));
                    _animator.SetTrigger("AttackSide");
                }
            }
            //up or down
            else
            {
                if (currentShootDirection.y > 0)
                {
                    StartCoroutine(AttackColliderOn(UpAttackCollider));
                    _animator.SetTrigger("AttackUp");
                }
                else
                {
                    StartCoroutine(AttackColliderOn(DownAttackCollider));
                    _animator.SetTrigger("AttackDown");
                }
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
