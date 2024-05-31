using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] Button _resumeButton;
    [SerializeField] Button _quitButton;

    private void Start()
    {
        _resumeButton.onClick.AddListener(ResumeGame);
        _quitButton.onClick.AddListener(QuitGame);
    }

    public void ResumeGame()
    {
        UIManager.manager.pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameManager.manager.gameIsPaused = false;
    }

    public void QuitGame()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }
}
