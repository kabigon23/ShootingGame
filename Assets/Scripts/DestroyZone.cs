using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Bullet") || other.gameObject.name.Contains("Enemy"))
        {
            other.gameObject.SetActive(false);
            if (other.gameObject.name.Contains("Bullet"))
            {
                PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
                player.bulletObjectPool.Add(other.gameObject);
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
