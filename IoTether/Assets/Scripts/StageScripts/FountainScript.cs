using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FountainScript : MonoBehaviour
{
    protected bool ableToRefill = false;
    private bool hasRefilled = false;
    public GameObject refillPerk;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasRefilled)
        {
            ableToRefill = true;
            UIManager.manager.EnableInteractPanel();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ableToRefill = false;
            UIManager.manager.DisableInteractPanel();
        }
    }
  
    private void Update()
    {
        if (ableToRefill && Input.GetKeyDown(KeyCode.F) && !GameManager.manager.gameIsPaused)
        {
            if (!hasRefilled)
            {
                TriggerRefill();
                hasRefilled = true;
            }
        }
    }

    public virtual void TriggerRefill()
    {
        GameObject player = GameObject.Find("Player");
        Instantiate(refillPerk, player.transform.position + Vector3.down, Quaternion.identity);
        UIManager.manager.DisableInteractPanel();
    }

   
}
