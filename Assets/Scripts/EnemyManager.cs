using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    float minTime = 0.1f;
    float maxTime = 1.5f;
    float currentTime;
    public float createTime;
    public GameObject enemyFactory;
    public int poolSize = 10;
    GameObject[] enemyObjectPool;
    public Transform[] spawnPoints;

    void Start()
    {
        createTime = Random.Range(minTime, maxTime);
        enemyObjectPool = new GameObject[poolSize];
        for (int i =0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyFactory);
            enemyObjectPool[i] = enemy;
            enemy.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= createTime)
        {
            for (int i=0; i < poolSize; i++)
            {
                GameObject enemy = enemyObjectPool[i];
                if (enemy.activeSelf == false)
                {
                    int index = Random.Range(0, spawnPoints.Length);
                    enemy.transform.position = spawnPoints[index].position;
                    enemy.SetActive(true);
                    break;
                }
            }
            
            currentTime = 0;
            createTime = Random.Range(minTime, maxTime);
        }
    }
}
