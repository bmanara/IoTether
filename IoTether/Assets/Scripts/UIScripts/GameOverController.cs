using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public TMP_Text pointsText;
    [SerializeField] Button _restartButton;
    [SerializeField] Button _mainMenuButton;

    private void Start()
    {
        _restartButton.onClick.AddListener(RestartGame);
        _mainMenuButton.onClick.AddListener(MainMenu);
    }

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = "Score: " + score.ToString();
    }

    public void RestartGame()
    {
        GameManager.manager.Restart();
        this.gameObject.SetActive(false);
    }

    public void MainMenu()
    {
        ScenesManager.manager.LoadStartMenu();
        this.gameObject.SetActive(false);
    }
}
