using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private int damage = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
            enemy.DecreaseHealth(damage);
        }
        else if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "TriggerBox")
        {
            Destroy(gameObject);
        }

        Destroy(gameObject, 2f);
    }
}
