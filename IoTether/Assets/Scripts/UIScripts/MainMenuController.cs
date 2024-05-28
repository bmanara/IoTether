using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] Button _playButton;

    private void Start()
    {
        _playButton.onClick.AddListener(PlayGame);
    }

    private void PlayGame()
    {
        ScenesManager.manager.LoadScene(ScenesManager.Scene.TutorialScene);
    }
}
