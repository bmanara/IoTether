using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FountainController : InteractableProp
{
    public GameObject refillPerk;
    
  
    protected override void Trigger()
    {
        GameObject player = GameObject.Find("Player");
        Instantiate(refillPerk, player.transform.position + Vector3.down, Quaternion.identity);
        UIManager.manager.DisableInteractPanel();
    }

   
}
