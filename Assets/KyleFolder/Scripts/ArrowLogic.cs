using System.Collections;
using UnityEngine;

public class ArrowLogic : MonoBehaviour
{
    public float arrowDamage;
    private void Start()
    {
        StartCoroutine(TimeUntilDestroyArrow());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageablePlayer damageable = collision.gameObject.GetComponent<IDamageablePlayer>();
        if (damageable != null)
        {
            damageable.DamageToPlayerHealth(arrowDamage);
            Destroy(gameObject);
        }
    }

    private IEnumerator TimeUntilDestroyArrow()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
