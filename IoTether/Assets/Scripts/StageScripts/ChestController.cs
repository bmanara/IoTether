using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : InteractableProp
{
    private GameObject Closed;
    private GameObject Opened;
    private GameObject Prompt;
    public GameObject[] ChestDrops;

    private void Start()
    {
        Closed = gameObject.transform.GetChild(0).gameObject;
        Opened = gameObject.transform.GetChild(1).gameObject;
        Prompt = gameObject.transform.GetChild(2).gameObject;
        Close();
        
    }

    protected override void Trigger()
    {
        Open();
        GameObject player = GameObject.Find("Player");
        if (ChestDrops.Length > 0)
        {
            int randomIndex = Random.Range(0, ChestDrops.Length);
            Instantiate(ChestDrops[randomIndex], player.transform.position + Vector3.down, Quaternion.identity);
        }
        AudioManager.manager.PlaySFX("ChestOpen");
        UIManager.manager.DisableInteractPanel();
    }


    private void Open()
    {
        Closed.SetActive(false);
        Opened.SetActive(true);
        Prompt.SetActive(false);
    }

    private void Close()
    {
        Closed.SetActive(true);
        Opened.SetActive(false);
    }

}
