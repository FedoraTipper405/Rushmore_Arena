using System.Collections;
using UnityEngine;

public class EnemyAttackCheck : MonoBehaviour
{
    public GameObject PlayerTarget { get; set; }
    private BaseEnemy _baseEnemy;
    private Collider2D _collider;
    [SerializeField] public float _timer;

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
            damageable.DamageToPlayerHealth(1f);
            Debug.Log("I hit");
        }

        if (collision.gameObject == PlayerTarget)
        {
            StartCoroutine(CanAttackAgain());
            _collider.enabled = false;
        }
    }
    private IEnumerator CanAttackAgain()
    {
        yield return new WaitForSeconds(_timer);
        _collider.enabled = true;
    }
}
