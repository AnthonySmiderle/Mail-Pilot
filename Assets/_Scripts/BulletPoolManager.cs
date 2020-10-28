using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Bonus - make this class a Singleton!

[System.Serializable]
public class BulletPoolManager : MonoBehaviour
{
    public GameObject bullet;
    private Queue<GameObject> bulletPool = new Queue<GameObject>();
    public int maxPool = 10;


    void MakeBulletPool()
    {
        for (int i = 0; i < maxPool; i++)
        {
            var temp = GameObject.Instantiate(bullet);
            temp.transform.SetParent(gameObject.transform);
            temp.SetActive(false);
            bulletPool.Enqueue(temp);

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        MakeBulletPool();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject GetBullet()
    {
        if (bulletPool.Count > 0){
            var temp = bulletPool.Dequeue();
            temp.SetActive(true);
            return temp;
        }
        return null;
    }

    public void ResetBullet(GameObject bullet)
    {
        if (bulletPool.Count == maxPool)
            return;
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet);
    }
    public int SizeOfBulletPool()
    {
        return bulletPool.Count;
    }
    public bool IsPoolEmpty()
    {
        return bulletPool.Count == 0 ? true : false;
    }
}
