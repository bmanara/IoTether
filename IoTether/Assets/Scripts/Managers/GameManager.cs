using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager manager { get; private set; }
    public int score = 0;
    public int gameLevel;
    public bool gameIsOver;

    public GameOverController gameOverController;

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
        DontDestroyOnLoad(this);
    }

    public void GameOver()
    {
        gameOverController.Setup(score);
    }
}
