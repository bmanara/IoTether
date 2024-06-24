using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnergyPerk", menuName = "Perks/EnergyPerk")]
public class EnergyPerk : IPerk
{

    public float percentage;
    public override void Apply(GameObject target)
    {
        GameObject playerParent = target.transform.parent.gameObject;
        playerParent.GetComponent<PlayerEnergy>().IncreaseMaxEnergyByPercentage(percentage);
        playerParent.GetComponent<PlayerEnergy>().replenishEnergy();
    }
}
