using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    private readonly int defaultHealth = 10;

    private int health;
    private int maxHealth = 10;
    private int prevHealth;

    private Material matWhite;
    private Material matDefault;
    private SpriteRenderer sr;


    private void Awake()
    {
        sr = gameObject.GetComponentInChildren<SpriteRenderer>();
        health = maxHealth;
        prevHealth = maxHealth;
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material; // as Material is type casting
        matDefault = sr.material;

        UpdateHealthBar();
    }

    public void Heal(int amount)
    {
        health += amount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        UpdateHealthBar();
    }

    public void DecreaseHealth(int damage)
    {
        OnHit(damage);
        UpdateHealthBar();
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
        
        Invoke("ResetMaterial", .1f);
    }

    private void Die()
    {
        GameManager.manager.GameOver();
    }

    void ResetMaterial()
    {
        sr.material = matDefault;
    }

    public void SaveHealth()
    {
        prevHealth = health;
        UpdateHealthBar();
    }

    public void ReloadHealth()
    {
        health = prevHealth;
        UpdateHealthBar();
    }

    public void ResetHealth()
    {
        maxHealth = defaultHealth;
        health = maxHealth;
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        UIManager.manager.SetHealth(health, maxHealth);
    }

    // Used for HealthPerk

    public void SetMaxHealth(int health)
    {
        maxHealth = health;
        UpdateHealthBar();
    }

    public void IncrementHealth(int health)
    {
        maxHealth += health;
        UpdateHealthBar();
    }
}
