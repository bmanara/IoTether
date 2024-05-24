using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    private int health;
    private int maxHealth = 10;

    private Material matWhite;
    private Material matDefault;
    private SpriteRenderer sr;

    private void Awake()
    {
        sr = gameObject.GetComponentInChildren<SpriteRenderer>();
        health = maxHealth;
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material; // as Material is type casting
        matDefault = sr.material;
    }

    private void Start()
    {
        UIManager.manager.SetMaxHealth(maxHealth);
        UIManager.manager.SetHealth(health);
    }

    public void DecreaseHealth(int damage)
    {
        OnHit(damage);
        UIManager.manager.SetHealth(health);
    }

    public void DecreaseHealth(int damage, Vector2 knockback)
    {
        throw new System.NotImplementedException();
    }

    private void OnHit(int damage)
    {
        sr.material = matWhite;
        health = health - damage;
        if (health <= 0)
        {
            Die();
        }
        else
        {
            Invoke("ResetMaterial", .1f);
        }
    }

    private void Die()
    {
        GameManager.manager.GameOver();
    }

    void ResetMaterial()
    {
        sr.material = matDefault;
    }
}
