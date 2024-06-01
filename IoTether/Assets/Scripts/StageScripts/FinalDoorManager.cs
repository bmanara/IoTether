using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FinalDoorManager : DoorManager
{
    private void LoadScene()
    {
        GameManager.manager.NextLevel();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && base.checkOpen())
        {
            Debug.Log("Player walked through door");
            LoadScene();
        }
    }
}
