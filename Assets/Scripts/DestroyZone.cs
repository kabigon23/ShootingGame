using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    GameObject playerObject;
    private void Awake()
    {
        playerObject = GameObject.Find("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Bullet") || other.gameObject.name.Contains("Enemy"))
        {
            other.gameObject.SetActive(false);
            if (other.gameObject.name.Contains("Bullet"))
            {
                if (playerObject != null)
                {
                    PlayerFire player = playerObject.GetComponent<PlayerFire>();
                    player.bulletObjectPool.Add(other.gameObject);
                }
                
            } else
            {
                EnemyManager manager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
                manager.enemyObjectPool.Add(other.gameObject);
            }
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
