using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] Button _resumeButton;
    [SerializeField] Button _quitButton;
    [SerializeField] Button _mainMenuButton;

    private void Start()
    {
        _resumeButton.onClick.AddListener(ResumeGame);
        _quitButton.onClick.AddListener(QuitGame);
        _mainMenuButton.onClick.AddListener(LaunchMenu);
    }

    public void ResumeGame()
    {
        UIManager.manager.pauseMenu.SetActive(false);
        GameManager.manager.UnpauseGame();
    }

    public void QuitGame()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }

    public void LaunchMenu()
    {
        GameManager.manager.PauseGame();
        GameManager.manager.LoadStartMenu();
    }
}
