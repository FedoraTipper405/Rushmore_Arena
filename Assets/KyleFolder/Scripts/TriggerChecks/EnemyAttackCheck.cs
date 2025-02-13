using System.Collections;
using UnityEngine;

public class EnemyAttackCheck : MonoBehaviour
{
    public GameObject PlayerTarget { get; set; }
    private BaseEnemy _baseEnemy;
    private Collider2D _collider;
    private float _timer => _baseEnemy.EnemyStatSO.AttackTimer;
    
    [SerializeField] private GameObject _slashEffect;
    [SerializeField] private GameObject _attackColllider1;
    [SerializeField] private GameObject _attackColllider2;

    private void Awake()
    {
        PlayerTarget = GameObject.FindGameObjectWithTag("Player");
        _collider = GetComponent<Collider2D>();
        _baseEnemy = GetComponentInParent<BaseEnemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageablePlayer damageable = collision.gameObject.GetComponent<IDamageablePlayer>();
        if (damageable != null)
        {
            damageable.DamageToPlayerHealth(_baseEnemy.DamageAmount);
        }

        if (collision.gameObject == PlayerTarget)
        {
            StartCoroutine(CanAttackAgain());
            StartCoroutine(SlashEffectTimer());
            _collider.enabled = false;
            _baseEnemy.EnemyAnimator.SetTrigger("Attack");
        }
    }
    private IEnumerator CanAttackAgain()
    {
        _attackColllider1.SetActive(false);
        _attackColllider2.SetActive(false);
        yield return new WaitForSeconds(_timer);
        _collider.enabled = true;
        _attackColllider1.SetActive(true);
        _attackColllider2.SetActive(true);
    }
   
    private IEnumerator SlashEffectTimer()
    {
        _slashEffect.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        _slashEffect.SetActive(false);
    }  
}
