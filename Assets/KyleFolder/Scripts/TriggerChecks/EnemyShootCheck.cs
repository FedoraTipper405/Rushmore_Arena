using System.Collections;
using UnityEngine;

public class EnemyShootCheck : MonoBehaviour
{
    public GameObject PlayerTarget { get; set; }
    private Transform _playerTransform;
    private BaseEnemy _baseEnemy;
    private Collider2D _collider;
    [SerializeField] public float _timer;
    [SerializeField] private SOArrowHolder _arrowHolder;
    public float arrowspeed;
    private bool _canDetect = true;
    [SerializeField] public float _detectTimer;
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
            ShootArrow();
            _baseEnemy.EnemyAnimator.SetTrigger("ShootArrow");
            StartCoroutine(CanAttackAgain());
            _collider.enabled = false;
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

    private void ShootArrow()
    {
        Vector2 direction = (_playerTransform.position - _baseEnemy.transform.position).normalized;
        GameObject shotArrow = Instantiate(_arrowHolder.ArrowPrefab, _baseEnemy.transform.position, Quaternion.identity);
        shotArrow.GetComponent<Rigidbody2D>().linearVelocity = direction * arrowspeed;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        shotArrow.transform.rotation = Quaternion.Euler(0,0, rot + 180);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(_detectTransform.position, _detectArea);
    }
}
