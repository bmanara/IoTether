using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(fileName = "EnergyPerk", menuName = "Perks/EnergyPerk")]
public class EnergyPerk : IPerk
{

    public int amount;
    public override void Apply(GameObject target)
    {
        GameObject playerParent = target.transform.parent.gameObject;
        playerParent.GetComponent<PlayerEnergy>().IncreaseMaxEnergy(amount);
        playerParent.GetComponent<PlayerEnergy>().replenishEnergy();
    }
}
