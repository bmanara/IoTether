using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilBossController : Enemy
{
    public GameObject projectile;
    protected Transform firePoint;

    private int numberOfProjectiles = 14;
    private float radius = 5f;

    private bool isEnraged = false;

    protected override void Init()
    {
        base.Init();
        health = 120;
        // ai.speed = 1;
        damage = 1;

        energyDrop = 100;
        healthDrop = 2;

        firePoint = transform.Find("FirePoint");
    }

    protected override void Update()
    {
        base.Update();

        if (!isEnraged && health <= 60)
        {
            Enrage();
        }
    }

    public void Attack()
    {
        GetComponent<AudioSource>().Play();

        Vector2 direction = new Vector2(0, 1);

        float angleStep = 360f / numberOfProjectiles;
        float angle = 0f;

        for (int i = 0; i < numberOfProjectiles; i++)
        {
            float projectileDirX = firePoint.position.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirY = firePoint.position.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector2 projectileVector = new Vector2 (projectileDirX, projectileDirY);
            Vector2 projectileMoveDir = (projectileVector - (Vector2)firePoint.position).normalized * 5f;

            GameObject bullet = EnemyBulletController.Create(projectile, firePoint, damage);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(projectileMoveDir.x, projectileMoveDir.y);

            angle += angleStep;
        }
    }

    private void Enrage()
    {
        isEnraged = true;
        numberOfProjectiles += 6;
        GetComponent<Animator>().SetTrigger("isEnraged");
        Color tmp = Color.red;
        tmp.a = 0.8f;
        GetComponent<SpriteRenderer>().color = tmp;
    }
}
