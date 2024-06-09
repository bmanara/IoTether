using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private bool ableToTalk = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ableToTalk = true;
            UIManager.manager.EnableInteractPanel();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ableToTalk = false;
            UIManager.manager.DisableInteractPanel();
        }
    }

    private void Update()
    {
        if (ableToTalk && Input.GetKeyDown(KeyCode.F) && !GameManager.manager.gameIsPaused)
        {
            TriggerDialogue();
        }
    }

    public void TriggerDialogue()
    {
        UIManager.manager.StartDialogue(dialogue);
    }
}
