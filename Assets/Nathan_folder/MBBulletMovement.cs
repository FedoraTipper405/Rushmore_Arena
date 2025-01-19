using UnityEngine;

public class MBBulletMovement : MonoBehaviour
{
    public Vector3 moveDirection;
    public float moveSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        this.transform.position += moveDirection * moveSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
