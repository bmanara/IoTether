using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BananaController : InteractableProp
{ 

    public void haha()
    {
        GameObject playerParent = GameObject.Find("PlayerParent");
        playerParent.GetComponent<PlayerHealth>().IncrementHealth(100);
        playerParent.GetComponent<PlayerHealth>().ReplenishHealth();
    }
    protected override void Trigger()
    {
        Color yellow = new Color32(255, 233, 0, 255);
        UIManager.manager.PlayAdaptiveText("Banana!", yellow, 0.7f, 0.3f, 45);
        Destroy(gameObject);
        //haha();
    }
}
