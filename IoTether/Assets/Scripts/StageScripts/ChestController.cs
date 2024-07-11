using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : InteractableProp
{
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

    protected override void Trigger()
    {
        Open();
        GameObject player = GameObject.Find("Player");
        Instantiate(chestDrop, player.transform.position + Vector3.down, Quaternion.identity);
        UIManager.manager.DisableInteractPanel();
    }


    private void Open()
    {
        closed.SetActive(false);
        opened.SetActive(true);
        prompt.SetActive(false);
    }

    private void Close()
    {
        closed.SetActive(true);
        opened.SetActive(false);
    }

}
