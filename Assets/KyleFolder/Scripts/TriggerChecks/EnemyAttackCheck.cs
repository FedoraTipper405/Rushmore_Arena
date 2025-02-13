using System.Collections;
using UnityEngine;

public class EnemyAttackCheck : MonoBehaviour
{
    public GameObject PlayerTarget { get; set; }
    private BaseEnemy _baseEnemy;
    private Collider2D _collider;
    private bool _canDetect = true;
    private float _timer => _baseEnemy.EnemyStatSO.AttackTimer;
    private float _detectTimer => _baseEnemy.EnemyStatSO.DetectTimer;
    
    [SerializeField] private Transform _detectTransform;
    [SerializeField] private Vector2 _detectArea;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private GameObject _slashEffect;

    private void Awake()
    {
        PlayerTarget = GameObject.FindGameObjectWithTag("Player");
        _collider = GetComponent<Collider2D>();
        _baseEnemy = GetComponentInParent<BaseEnemy>();
    }

    private void FixedUpdate()
    {
        if(_canDetect == true)
        {
            Collider2D[] objectsHit = Physics2D.OverlapBoxAll(_detectTransform.position, _detectArea, 0, _layerMask);

            if (objectsHit.Length > 0)
            {
                _baseEnemy.ObjectInTheWay(true);
            }
            _canDetect = false;
            StartCoroutine(DetectAgain());
        }
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
        yield return new WaitForSeconds(_timer);
        _collider.enabled = true;
    }
    private IEnumerator DetectAgain()
    {
        yield return new WaitForSeconds(_detectTimer);
        _canDetect = true;
    }

    private IEnumerator SlashEffectTimer()
    {
        _slashEffect.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        _slashEffect.SetActive(false);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(_detectTransform.position, _detectArea);
    }
}
