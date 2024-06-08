using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] Button _playButton;
    [SerializeField] Button _quitButton;

    private void Start()
    {
        _playButton.onClick.AddListener(PlayGame);
        _quitButton.onClick.AddListener(QuitGame);
    }

    private void PlayGame()
    {
        GameManager.manager.StartGame();
    }

    private void QuitGame()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }
}
