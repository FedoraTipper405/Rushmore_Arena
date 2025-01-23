using UnityEngine;

public class EnemyAttackCheck : MonoBehaviour
{
    public GameObject PlayerTarget {  get; set; }
    private BaseEnemy _enemy;

    private void Awake()
    {
        PlayerTarget = GameObject.FindGameObjectWithTag("Player");

        _enemy = GetComponentInParent<BaseEnemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == PlayerTarget)
        {
            _enemy.AttackPlayer(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == PlayerTarget)
        {
            _enemy.AttackPlayer(false);
        }
    }
}
