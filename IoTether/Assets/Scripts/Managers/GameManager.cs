using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager manager { get; private set; }
    public int score = 0;
    public int gameLevel;
    public bool gameIsOver;

    public static event Action OnGameOver;

    private void Awake()
    {
        // Singleton Pattern
        if (manager != null && manager != this)
        {
            Destroy(this);
        }
        else
        {
            manager = this;
        }

        DontDestroyOnLoad(manager);
    }

    public void GameOver()
    {
        OnGameOver?.Invoke();
    }

    public void Restart()
    {
        // will need to reset the score to previously saved score
        ScenesManager.manager.RestartScene();
        PlayerControllers.Instance.GetComponent<PlayerHealth>().UpdateHealthBar();
    }
}
