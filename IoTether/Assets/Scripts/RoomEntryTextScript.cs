using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class RoomEntryTextScript : MonoBehaviour
{
    
    public float fadeDuration = 1f;
    public float displayDuration = 2f;
    private bool hasFadedIn = false;

    public string entryText;
    public bool isBossRoom = false;

    //private static int level = 0;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasFadedIn)
        {
            UIManager.manager.EnableEntryText();
            UIManager.manager.ChangeText(entryText);
            if (isBossRoom)
            {
                UIManager.manager.ChangeTextColour(new Color32(255, 65, 57, 255));
            }
            StartCoroutine(UIManager.manager.FadeText(true, fadeDuration, displayDuration));
            hasFadedIn = true;
        }
    }

}
