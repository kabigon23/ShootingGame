using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5;
    Vector3 dir;
    public GameObject explosionFactory;
    GameObject playerObject;

    private void OnCollisionEnter(Collision other)
    {
        GameObject explosion = Instantiate(explosionFactory);
        ScoreManager.Instance.score++;
        explosion.transform.position = transform.position;
        if (other.gameObject.name.Contains("Bullet"))
        {
            other.gameObject.SetActive(false);
            if (playerObject != null)
            {
                PlayerFire player = playerObject.GetComponent<PlayerFire>();
                player.bulletObjectPool.Add(other.gameObject);
            }
        }
        else
        {
            Destroy(other.gameObject);
        }
        
        gameObject.SetActive(false);
        GameObject emObject = GameObject.Find("EnemyManager");
        EnemyManager manager = emObject.GetComponent<EnemyManager>();

        manager.enemyObjectPool.Add(gameObject);
        

    }
    private void Awake()
    {
        playerObject = GameObject.Find("Player");
        
    }
    void OnEnable()
    {
        if (playerObject != null)
        {
            int randValue = Random.Range(1, 10);
            if (randValue < 3)
            {
                dir = playerObject.transform.position - transform.position;
                dir.Normalize();
            }
            else
            {
                dir = Vector3.down;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }
}
