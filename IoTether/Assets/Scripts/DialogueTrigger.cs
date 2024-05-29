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
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ableToTalk = false;
        }
    }

    private void Update()
    {
        if (ableToTalk && Input.GetKeyDown(KeyCode.F))
        {
            TriggerDialogue();
        }
    }

    public void TriggerDialogue()
    {
        UIManager.manager.StartDialogue(dialogue);
    }
}
