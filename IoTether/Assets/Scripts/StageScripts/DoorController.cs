using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    private GameObject Closed;
    private GameObject Opened;
    private bool isOpen = false;

    public List<Enemy> enemies;

    private float fadeDuration = 0.7f;
    private float displayDuration = 0.3f;

    private bool isRestarting = false;

    private void Start()
    {
        Closed = gameObject.transform.GetChild(0).gameObject;
        Opened = gameObject.transform.GetChild(1).gameObject;
        Close();

        foreach (var enemy in enemies)
        {
            enemy.OnEnemyDefeated += CheckEnemies;
        }

        GameManager.OnGameRestart += OnGameRestarted; 
    }

    private void OnDestroy()
    {
        foreach (var enemy in enemies)
        {
            if (enemy != null)
            {
                enemy.OnEnemyDefeated -= CheckEnemies;
            }
        }

        GameManager.OnGameRestart -= OnGameRestarted;
    }

    private void CheckEnemies()
    {
        foreach (var enemy in enemies)
        {
            if (enemy != null && enemy.isActiveAndEnabled)
            {
                return;
            }
        }
        Open();
    }

    [ContextMenu("Close")]
    private void Close()
    {
        Closed.SetActive(true);
        Opened.SetActive(false);
        isOpen = false;
    }

    [ContextMenu("Open")]
    private void Open()
    {
        if (!isOpen)
        {
            Closed.SetActive(false);
            Opened.SetActive(true);
            isOpen = true;

            if (!isRestarting) // Only play adaptive text if the game is not restarting
            {
                AudioManager.manager.PlaySFX("RoomClear");
                PlayAdaptiveText();
            }
        }
    }

    protected virtual void PlayAdaptiveText()
    {
        Color green = new Color32(0, 255, 0, 255);
        UIManager.manager.PlayAdaptiveText("Room Cleared!", green, fadeDuration, displayDuration, 45);
    }

    public bool checkOpen()
    {
        return isOpen;
    }

    private void OnGameRestarted()
    {
        isRestarting = true;
        Invoke("ResetRestartingFlag", 1f); // Reset the flag after a short delay
    }

    private void ResetRestartingFlag()
    {
        isRestarting = false;
    }
}