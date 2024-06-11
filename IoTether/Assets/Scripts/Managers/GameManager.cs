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
    private bool gameWasPaused = false;

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

    public void LoadStartMenu()
    {
        ScenesManager.manager.LoadStartMenu();
        if (PlayerControllers.Instance != null)
        {
            PlayerControllers.Instance.DestroySelf(); // horrible coding what did cs2030s teach you!
        }

        if (UIManager.manager != null)
        {
            UIManager.manager.DestroySelf();
        }

    }

    public void StartGame()
    {
        score = 0;
        prevScore = 0;
        gameLevel = 0;
        gameIsOver = false;
        gameWasPaused = false;
        manager.UnpauseGame();

        ScenesManager.manager.LoadTutorial(); // might need to change whether we want to load tutorial or not
    }

    public void PauseGame()
    {
        if (gameIsPaused)
        {
            gameWasPaused = true;
        }
        else
        {
            gameWasPaused = false;
        }

        Time.timeScale = 0;
        gameIsPaused = true;
    }

    public void UnpauseGame()
    {
        if (!gameWasPaused)
        {
            Time.timeScale = 1;
            gameIsPaused = false;
        } 
        else
        {
            gameWasPaused = false;
        }
    }

    public void Restart()
    {
        // will need to reset the score to previously saved score
        score = prevScore;
        ScenesManager.manager.RestartScene();
        // PlayerControllers.Instance.Respawn(GameObject.Find("SpawnPoint").transform.position);
        StartCoroutine(RespawnPlayer(0));
        PlayerControllers.Instance.GetComponent<PlayerHealth>().ReloadHealth();
        PlayerControllers.Instance.gameObject.GetComponentInChildren<WeaponSwitching>().LoadWeapons();
        PlayerControllers.Instance.GetComponent<PlayerEnergy>().ReloadEnergy();
        
    }

    public void NextLevel()
    {
        gameLevel += 1;
        SaveScore();
        ScenesManager.manager.LoadNextScene();
        //PlayerControllers.Instance.Respawn(GameObject.Find("SpawnPoint").transform.position);
        StartCoroutine(RespawnPlayer(0.001f));
        PlayerControllers.Instance.GetComponent<PlayerHealth>().SaveHealth();
        PlayerControllers.Instance.gameObject.GetComponentInChildren<WeaponSwitching>().SaveWeapons();
        PlayerControllers.Instance.GetComponent<PlayerEnergy>().SaveEnergy();
      
    }

    //Added delay so SpawnPoint can fully reload before spawning player 
    private IEnumerator RespawnPlayer(float delay)
    {
        //Wait for the scene to be fully loaded
        yield return new WaitForSeconds(delay);

        Transform spawnPoint = GameObject.Find("SpawnPoint").transform;
        PlayerControllers.Instance.Respawn(spawnPoint.position);
       
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
