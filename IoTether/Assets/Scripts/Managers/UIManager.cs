using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager manager { get; private set; }

    public HealthBarController healthBar;
    public GameObject gameOverMenu;

    private void Awake()
    {
        manager = this;
    }

    private void OnEnable()
    {
        GameManager.OnGameOver += EnableGameOverMenu;
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= EnableGameOverMenu;
    }

    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }

    public void SetMaxHealth(int maxHealth)
    {
        healthBar.SetMaxHealth(maxHealth);
    }

    public void SetHealth(int health)
    {
        healthBar.SetHealth(health);
    }
}
