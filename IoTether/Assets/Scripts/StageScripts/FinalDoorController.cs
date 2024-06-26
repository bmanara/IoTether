using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FinalDoorController : DoorController
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

    protected override void Open()
    {
        base.Open();
        this.PlayAdaptiveText();
    }

    protected override void PlayAdaptiveText()
    {
        //Plays adaptive text with orange colour to indicate stage clear
        Color orange = new Color32(242, 141, 0, 255);
        UIManager.manager.PlayAdaptiveText("Stage Cleared!", orange, 0.7f, 0.3f, 45);

    }
}
