using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    private bool hasOpened = false;
    protected bool canDrop = false;
    private GameObject closed;
    private GameObject opened;
    private GameObject prompt;
    public GameObject chestDrop;

    private void Start()
    {
        closed = gameObject.transform.GetChild(0).gameObject;
        opened = gameObject.transform.GetChild(1).gameObject;
        prompt = gameObject.transform.GetChild(2).gameObject;
        Close();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasOpened)
        {
            canDrop = true;
            UIManager.manager.EnableInteractPanel();
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canDrop = false;
            UIManager.manager.DisableInteractPanel();
        }
    }

    private void Update()
    {
        if (canDrop && Input.GetKeyDown(KeyCode.F) && !GameManager.manager.gameIsPaused)
        {
            if (!hasOpened)
            {
                TriggerOpen();
                hasOpened = true;
            }
        }
    }

    public virtual void TriggerOpen()
    {
        Open();
        GameObject player = GameObject.Find("Player");
        Instantiate(chestDrop, player.transform.position + Vector3.down, Quaternion.identity);
        UIManager.manager.DisableInteractPanel();
    }

    private void Open()
    {
        opened.SetActive(true);
        closed.SetActive(false);
        prompt.SetActive(false);
    }

    private void Close()
    {
        closed.SetActive(true);
        opened.SetActive(false);
    }
}
