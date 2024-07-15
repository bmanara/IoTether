using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : InteractableProp
{
    private GameObject closed;
    private GameObject opened;
    private GameObject prompt;
    public GameObject[] chestDrops;

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
        if (chestDrops.Length > 0)
        {
            int randomIndex = Random.Range(0, chestDrops.Length);
            Instantiate(chestDrops[randomIndex], player.transform.position + Vector3.down, Quaternion.identity);
        }
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
