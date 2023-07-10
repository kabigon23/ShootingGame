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
    public List<GameObject> enemyObjectPool;
    public Transform[] spawnPoints;

    void Start()
    {
        createTime = Random.Range(minTime, maxTime);
        enemyObjectPool = new List<GameObject>();
        for (int i =0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyFactory);
            enemyObjectPool.Add(enemy);
            enemy.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= createTime)
        {
            
            if (enemyObjectPool.Count > 0)
            {
                GameObject enemy = enemyObjectPool[0];
                enemy.SetActive(true);
                enemyObjectPool.Remove(enemy);
                
                
                int index = Random.Range(0, spawnPoints.Length);
                enemy.transform.position = spawnPoints[index].position;
                
                
                
            }
            
            currentTime = 0;
            createTime = Random.Range(minTime, maxTime);
        }
    }
}
