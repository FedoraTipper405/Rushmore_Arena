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

    private void Awake()
    {
        PlayerTarget = GameObject.FindGameObjectWithTag("Player");
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        _collider = GetComponent<Collider2D>();
        _baseEnemy = GetComponentInParent<BaseEnemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == PlayerTarget)
        {
            ShootArrow();
            StartCoroutine(CanAttackAgain());
            _collider.enabled = false;
        }
    }

    private IEnumerator CanAttackAgain()
    {
        yield return new WaitForSeconds(_timer);
        _collider.enabled = true;
    }

    private void ShootArrow()
    {
        Vector2 direction = (_playerTransform.position - _baseEnemy.transform.position).normalized;
        GameObject shotArrow = Instantiate(_arrowHolder.ArrowPrefab, _baseEnemy.transform.position, Quaternion.identity);
        shotArrow.GetComponent<Rigidbody2D>().linearVelocity = direction * arrowspeed;
    }
}
