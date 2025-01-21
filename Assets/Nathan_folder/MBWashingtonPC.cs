using UnityEngine;

public class MBWashingtonPC : MBBasePlayerController
{
    [SerializeField] private MBBulletPooling bulletPoolScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public override void Attack()
    {
        GameObject lastBullet = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);
        lastBullet.GetComponent<MBBulletMovement>().moveDirection = currentShootDirection; 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
