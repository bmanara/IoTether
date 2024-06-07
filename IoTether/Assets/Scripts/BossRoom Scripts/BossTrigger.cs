using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
   private bool isTriggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
         if (other.CompareTag("Player") && !isTriggered)
        {
              isTriggered = true;
              // Trigger Boss Fight
         }
    }

    public bool isBossTriggered()
    {
        return isTriggered;
    }
}
