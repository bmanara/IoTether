using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HealthPerk", menuName = "Perks/HealthPerk")]
public class HealthPerk : IPerk
{
    public int amount;
    public override void Apply(GameObject target)
    {
        GameObject playerParent = target.transform.parent.gameObject;
        playerParent.GetComponent<PlayerHealth>().IncrementHealth(amount);
        
    }
}
