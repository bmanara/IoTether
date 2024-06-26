using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkDialogueTrigger : DialogueTrigger
{
    public Dialogue postPerkDialogue;
    private bool firstDialogueDone = false;

    private void Update()
    {
        if (ableToTalk && Input.GetKeyDown(KeyCode.F) && !GameManager.manager.gameIsPaused)
        {
            if (!firstDialogueDone)
            {
                TriggerPrePerkDialogue();
                MarkFirstDialogueDone();
            }
            else
            {
                TriggerPostPerkDialogue();
            }
        }
    }

    public void TriggerPrePerkDialogue()
    {
        UIManager.manager.StartDialogue(dialogue);
    }

    public void TriggerPostPerkDialogue()
    {
        UIManager.manager.StartDialogue(postPerkDialogue);
    }

    public void MarkFirstDialogueDone()
    {
        firstDialogueDone = true;
    }
}