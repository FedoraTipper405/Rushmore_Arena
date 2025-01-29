using System.Collections;
using UnityEngine;

public class EnemyChargeCheck : MonoBehaviour
{
    public GameObject PlayerTarget { get; set; }
    private BaseEnemy _baseEnemy;
    [SerializeField] public float _stopTimer;
    [SerializeField] public float _startTimer;
    private Collider2D _collider;

    private void Awake()
    {
        PlayerTarget = GameObject.FindGameObjectWithTag("Player");
        _collider = GetComponent<Collider2D>();
        _baseEnemy = GetComponentInParent<BaseEnemy>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == PlayerTarget)
        {
            StartCoroutine(StopCharge());
            _baseEnemy.ChasePlayer(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == PlayerTarget)
        {
            StartCoroutine(CanChargeAgain());
            _baseEnemy.ChasePlayer(false);
        }
    }
    private IEnumerator CanChargeAgain()
    {
        yield return new WaitForSeconds(_startTimer);
        _collider.enabled = true;
    }
    private IEnumerator StopCharge()
    {
        yield return new WaitForSeconds(_stopTimer);
        _collider.enabled = false;
    }
}
