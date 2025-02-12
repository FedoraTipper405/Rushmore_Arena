using UnityEngine;

public class BossCheck : MonoBehaviour
{
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 4f);
    }
}
