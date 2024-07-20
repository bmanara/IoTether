using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;

public class ChrisController : Enemy
{
    public GameObject projectile;
    protected Transform firePoint;
    public BossBattle bossBattleLogic;

    private string bossName = "Chris";
    private int numberOfProjectiles = 15;
    private float radius = 5f;

    private bool isEnraged = false;

    public TreeStrikerController treeStrikerOne;
    public TreeStrikerController treeStrikerTwo;

    protected override void Init()
    {
        base.Init();

        health = 160;
        damage = 1;

        energyDrop = 160;
        healthDrop = 2;

        firePoint = transform.Find("FirePoint");

        UIManager.manager.SetBossHealth(health, 160);
        UIManager.manager.SetBossName(bossName);
    }

    protected override void Update()
    {
        base.Update();

        if (!isEnraged && health <= 80)
        {
            Enrage();
        }
    }

    protected override void KillSelf()
    {
        base.KillSelf();
        bossBattleLogic.StopBattle();
        treeStrikerOne.OnDestroy();
        treeStrikerTwo.OnDestroy();
    }

    private void Enrage()
    {
        isEnraged = true;
        GetComponent<Animator>().SetTrigger("isEnraged");

        Color tmp = Color.red;
        tmp.a = 0.5f;
        GetComponent<SpriteRenderer>().color = tmp;
        numberOfProjectiles = 20;
    }

    public override void DecreaseHealth(int damage)
    {
        base.DecreaseHealth(damage);
        UIManager.manager.SetBossHealth(health, 160);
    }

    public override void DecreaseHealth(int damage, Vector2 knockback)
    {
        base.DecreaseHealth(damage, knockback);
        UIManager.manager.SetBossHealth(health, 160);
    }

    public void Attack()
    {
        // Debug.Log("Chris Attacks! RAAAAAH");
        StartCoroutine("Shoot");
        GetComponent<AudioSource>().Play();
    }

    public void EnragedAttack()
    {
        // Debug.Log("Angry Chris Attacks! RAAAAAH");
        StartCoroutine("Shoot");
        GetComponent<AudioSource>().Play();
    }

    private IEnumerator Shoot()
    {
        float angleStep = 360f / numberOfProjectiles;
        float angle = 0f;

        for (int i = 0; i < numberOfProjectiles; i++)
        {
            float projectileDirX = firePoint.position.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirY = firePoint.position.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector2 projectileVector = new Vector2(projectileDirX, projectileDirY);
            Vector2 projectileMoveDir = (projectileVector - (Vector2)firePoint.position).normalized * 8f;

            GameObject bullet = EnemyBulletController.Create(projectile, firePoint, damage);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(projectileMoveDir.x, projectileMoveDir.y);

            angle += angleStep;

            yield return new WaitForSeconds(0.1f);
        }
    }
}
