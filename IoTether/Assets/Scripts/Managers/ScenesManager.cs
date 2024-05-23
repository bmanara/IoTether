using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager manager { get; private set; }

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

    public enum Scene
    {
        // Ordering of scenes must be the same as build settings
        StartMenuScene,
        TutorialScene,
        BrianScene
        // might need to change how we name our levels
    }

    // Methods to load scenes
    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene(Scene.TutorialScene.ToString());
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadStartMenu(int level)
    {
        SceneManager.LoadScene(Scene.StartMenuScene.ToString());
    }
}
