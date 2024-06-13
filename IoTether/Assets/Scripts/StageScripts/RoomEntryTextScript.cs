using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class RoomEntryTextScript : MonoBehaviour
{
    
    public float fadeDuration = 1f;
    public float displayDuration = 1f;
    private bool hasFadedIn = false;

    public string entryText;
    public bool isBossRoom = false;

    //private static int level = 0;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasFadedIn) // Only plays once
        {
            PlayAdaptiveText();
        }
    }

    private void PlayAdaptiveText()
    {
        // UIManager.manager.EnableAdaptiveText();
        // UIManager.manager.ChangeText(entryText);
        Color color;
        if (isBossRoom)
        {
            UIManager.manager.ChangeTextColour(new Color32(255, 65, 57, 255));
            color = new Color32(255, 65, 57, 255);
        }
        else
        {
            UIManager.manager.ChangeTextColour(new Color32(0, 232, 242, 255));
            color = new Color32(0, 232, 242, 255);
        }
        UIManager.manager.PlayAdaptiveText(entryText, color, fadeDuration, displayDuration);
        hasFadedIn = true;
    }

}
