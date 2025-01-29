using UnityEngine;

public class EnemyChaseCheck : MonoBehaviour
{
    public GameObject PlayerTarget { get; set; }
    private BaseEnemy _baseEnemy;

    private void Awake()
    {
        PlayerTarget = GameObject.FindGameObjectWithTag("Player");

        _baseEnemy = GetComponentInParent<BaseEnemy>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == PlayerTarget)
        {
            _baseEnemy.ChasePlayer(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == PlayerTarget)
        {
            _baseEnemy.ChasePlayer(false);
        }
    }
}
