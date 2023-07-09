using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;
    public GameObject firePosition;
    public int poolSize = 10;
    GameObject[] bulletObjectPool;

    void Start()
    {
        bulletObjectPool = new GameObject[poolSize];
        for (int i =0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletFactory);
            bulletObjectPool[i] = bullet;
            bullet.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            for (int i = 0; i < poolSize; i++)
            {
                GameObject bullet = bulletObjectPool[i];
                if(bullet.activeSelf == false)
                {
                    bullet.SetActive(true);
                    bullet.transform.position = firePosition.transform.position;
                    break;
                }
            }
            
        }
    }
}
