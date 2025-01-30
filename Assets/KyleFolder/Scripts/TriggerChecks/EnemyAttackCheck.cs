using System.Collections;
using UnityEngine;

public class EnemyAttackCheck : MonoBehaviour
{
    public GameObject PlayerTarget { get; set; }
    private BaseEnemy _baseEnemy;
    private Collider2D _collider;
    private bool _canDetect = true;
    [SerializeField] public float _timer;
    [SerializeField] public float _detectTimer = 0.5f;
    [SerializeField] private Transform _detectTransform;
    [SerializeField] private Vector2 _detectArea;
    [SerializeField] private LayerMask _layerMask;

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
            damageable.DamageToPlayerHealth(1f);
            Debug.Log("I hit");
        }

        if (collision.gameObject == PlayerTarget)
        {
            StartCoroutine(CanAttackAgain());
            _collider.enabled = false;
            _baseEnemy.EnemyAnimator.SetTrigger("Attack");
            _baseEnemy.EnemyAnimator.SetBool("CanAttack", true);
        }
    }
    private IEnumerator CanAttackAgain()
    {
        yield return new WaitForSeconds(_timer);
        _baseEnemy.EnemyAnimator.SetBool("CanAttack", false);
        _collider.enabled = true;
    }
    private IEnumerator DetectAgain()
    {
        yield return new WaitForSeconds(_detectTimer);
        _canDetect = true;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(_detectTransform.position, _detectArea);
    }
}
