using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChrisController : Enemy
{
    public GameObject projectile;
    protected Transform firePoint;
    public BossBattle bossBattleLogic;

    private string bossName = "Chris";

    private bool isEnraged = false;

    protected override void Init()
    {
        base.Init();

        health = 160;
        damage = 2;

        energyDrop = 160;
        healthDrop = 2;

        // TODO: Give firepoint to Chris
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
    }

    private void Enrage()
    {
        isEnraged = true;
        // TODO: Set up animator
        GetComponent<Animator>().SetTrigger("isEnraged");
        Color tmp = Color.red;
        tmp.a = 0.5f;
        GetComponent<SpriteRenderer>().color = tmp;
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
}
