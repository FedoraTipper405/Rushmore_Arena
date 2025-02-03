using System.Collections;
using UnityEngine;

public class EnemyShootCheck : MonoBehaviour
{
    public GameObject PlayerTarget { get; set; }
    private Transform _playerTransform;
    private BaseEnemy _baseEnemy;
    private Collider2D _collider;
    private float _timer => _baseEnemy.EnemyStatSO.AttackTimer;
    private float _detectTimer => _baseEnemy.EnemyStatSO.DetectTimer;
    private float _arrowspeed => _baseEnemy.EnemyStatSO.ArrowSpeed;
    private GameObject _arrowPrefab => _baseEnemy.EnemyStatSO.ArrowPrefab;
    private float _waitBeforeAnimation = 0.5f;

    private bool _canDetect = true;
    
    [SerializeField] private Transform _detectTransform;
    [SerializeField] private Vector2 _detectArea;
    [SerializeField] private LayerMask _layerMask;

    private void Awake()
    {
        PlayerTarget = GameObject.FindGameObjectWithTag("Player");
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        _collider = GetComponent<Collider2D>();
        _baseEnemy = GetComponentInParent<BaseEnemy>();
    }

    private void FixedUpdate()
    {
        if (_canDetect == true)
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
        if (collision.gameObject == PlayerTarget)
        {
            _baseEnemy.EnemyAnimator.SetTrigger("ShootArrow");
            StartCoroutine(FinishAnimationBeforeShooting());
            StartCoroutine(CanAttackAgain());
            _collider.enabled = false;
        }
    }

    private IEnumerator FinishAnimationBeforeShooting()
    {
        yield return new WaitForSeconds(_waitBeforeAnimation);
        ShootArrow();
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

    private void ShootArrow()
    {
        Vector2 direction = (_playerTransform.position - _baseEnemy.transform.position).normalized;
        GameObject shotArrow = Instantiate(_arrowPrefab, _baseEnemy.transform.position, Quaternion.identity);
        shotArrow.GetComponent<Rigidbody2D>().linearVelocity = direction * _arrowspeed;
        shotArrow.GetComponent<ArrowLogic>().arrowDamage = _baseEnemy.DamageAmount;
        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        shotArrow.transform.rotation = Quaternion.Euler(0,0, rot + 180);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(_detectTransform.position, _detectArea);
    }
}
