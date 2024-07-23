using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] Button _playButton;
    [SerializeField] Button _quitButton;
    [SerializeField] Slider _slider;

    private void Start()
    {
        _playButton.onClick.AddListener(PlayGame);
        _quitButton.onClick.AddListener(QuitGame);
        _slider.value = AudioManager.manager.GetMusicVolume();
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

    public void MusicVolume()
    {
        AudioManager.manager.MusicVolume(_slider.value);
    }

    public void SFXVolume()
    {
        AudioManager.manager.SFXVolume(_slider.value);
    }

}
