using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealth
{
    private int maxHealth;
    private int currHealth;

    public int Health
    {
        get { return currHealth; }
        set { currHealth = value; }
    }

    public int MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = value; }
    }

    public UnitHealth(int currHealth, int maxHealth)
    {
        this.maxHealth = maxHealth;
        this.currHealth = currHealth;
    }

    public void TakeDamage(int damage)
    {
        currHealth -= damage;
        if (currHealth < 0)
        {
            currHealth = 0;
        }
    }

    public void Heal(int healAmount)
    {
        currHealth += healAmount;
        if (currHealth > maxHealth)
        {
            currHealth = maxHealth;
        }
    }
}
