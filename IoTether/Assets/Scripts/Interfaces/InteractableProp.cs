using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableProp : MonoBehaviour
{
    protected bool canInteract = false;
    private bool hasInteracted = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasInteracted)
        {
            canInteract = true;
            UIManager.manager.EnableInteractPanel();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canInteract = false;
            UIManager.manager.DisableInteractPanel();
        }
    }

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.F) && !GameManager.manager.gameIsPaused)
        {
            if (!hasInteracted)
            {
                Trigger();
                hasInteracted = true;
            }
        }
    }

    protected abstract void Trigger();
    

}
