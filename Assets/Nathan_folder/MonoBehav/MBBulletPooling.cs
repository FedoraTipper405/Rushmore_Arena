using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBBulletPooling : MonoBehaviour
{
    public Queue<GameObject> Bulletpool = new Queue<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void AddToPool(GameObject bullet)
    {

        Bulletpool.Enqueue(bullet);
        bullet.SetActive(false);
    }

    public GameObject GetFromPool()
    {
        GameObject FirstInLine = Bulletpool.Peek();
        FirstInLine.SetActive(true);
        Bulletpool.Dequeue();
        return FirstInLine;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
