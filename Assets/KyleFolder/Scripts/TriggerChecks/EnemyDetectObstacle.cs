using System.Collections;
using UnityEngine;

public class EnemyDetectObstacle : MonoBehaviour
{
    [SerializeField] private Transform _detectTransform;
    [SerializeField] private Vector2 _detectArea;
    [SerializeField] private LayerMask _layerMask;

    private BaseEnemy _baseEnemy;
    private bool _canDetect = true;
    private float _detectTimer => _baseEnemy.EnemyStatSO.DetectTimer;

    private void Awake()
    {      
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
