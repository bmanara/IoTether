using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    private readonly int defaultHealth = 10;

    [SerializeField] private int health;
    private int maxHealth = 10;
    private int prevMaxHealth;
    private int prevHealth;

    private Material matWhite;
    private Material matDefault;
    private SpriteRenderer sr;

    private bool isDead = false;


    private void Awake()
    {
        sr = gameObject.GetComponentInChildren<SpriteRenderer>();
        health = maxHealth;
        prevHealth = maxHealth;
        prevMaxHealth = maxHealth;
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

    public void ReplenishHealth()
    {
        Heal(maxHealth);
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
        if (isDead) return;
        isDead = true;
        Debug.Log("invoking GameOver");
        GameManager.manager.GameOver();
    }

    void ResetMaterial()
    {
        sr.material = matDefault;
    }

    public void SaveHealth()
    {
        prevHealth = health;
        prevMaxHealth = maxHealth;
        UpdateHealthBar();
    }

    public void ReloadHealth()
    {
        health = prevHealth;
        maxHealth = prevMaxHealth;
        isDead = false;
        UpdateHealthBar();
    }

    public void ResetHealth()
    {
        maxHealth = defaultHealth;
        health = maxHealth;
        isDead = false;
        UpdateHealthBar();
    }

    [ContextMenu("Update Health Bar")]
    public void UpdateHealthBar()
    {
        if(UIManager.manager != null)
        {
            UIManager.manager.SetHealth(health, maxHealth);
        }
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

    // Testing purposes
    public int GetHealth()
    {
        return health;
    }

   
}
