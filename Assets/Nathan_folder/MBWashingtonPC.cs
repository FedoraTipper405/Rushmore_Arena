using UnityEngine;

public class MBWashingtonPC : MBBasePlayerController
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public override void HandleAttack()
    {
        GameObject lastBullet = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);
        lastBullet.GetComponent<MBBulletMovement>().moveDirection = lastMoveDirection;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
