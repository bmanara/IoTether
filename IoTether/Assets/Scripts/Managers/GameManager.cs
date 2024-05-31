using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager manager { get; private set; }
    public int score = 0;
    public int prevScore = 0;

    public int gameLevel = 0;
    public bool gameIsOver;
    public bool gameIsPaused = false;

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
        score = prevScore;
        ScenesManager.manager.RestartScene();
        PlayerControllers.Instance.Respawn(GameObject.Find("SpawnPoint").transform.position);
        PlayerControllers.Instance.GetComponent<PlayerHealth>().ReloadHealth();
        PlayerControllers.Instance.gameObject.GetComponentInChildren<WeaponSwap>().ReloadWeapon();
        PlayerControllers.Instance.GetComponent<PlayerHealth>().UpdateHealthBar();
    }

    public void NextLevel()
    {
        gameLevel += 1;
        SaveScore();
        ScenesManager.manager.LoadNextScene();
        PlayerControllers.Instance.Respawn(GameObject.Find("SpawnPoint").transform.position);
        PlayerControllers.Instance.GetComponent<PlayerHealth>().SaveHealth();
        PlayerControllers.Instance.gameObject.GetComponentInChildren<WeaponSwap>().SaveWeapon();
        PlayerControllers.Instance.GetComponent<PlayerHealth>().UpdateHealthBar();
    }

    public void IncreaseScore(int score)
    {
        this.score += score;
    }

    public void SaveScore()
    {
        prevScore = score;
    }

    public int GetScore()
    {
        return score;
    }
}
