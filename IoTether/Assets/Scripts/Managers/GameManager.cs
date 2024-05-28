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
    }

    public void NextLevel()
    {
        gameLevel += 1;
        SaveScore();
        PlayerControllers.Instance.Respawn(GameObject.Find("SpawnPoint").transform.position);
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
