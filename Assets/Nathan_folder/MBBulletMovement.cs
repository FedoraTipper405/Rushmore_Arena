using UnityEngine;

public class MBBulletMovement : MonoBehaviour
{
    public Vector3 moveDirection;
    public float moveSpeed;
    public float bulletRange;
    public float distanceTraveled;
    public MBBulletPooling bulletPooling;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        this.transform.position += moveDirection * moveSpeed;
        distanceTraveled += moveSpeed;
        if(distanceTraveled > bulletRange)
        {
            if (bulletPooling != null)
            {
                bulletPooling.AddToPool(this.gameObject);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
