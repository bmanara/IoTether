using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergy : MonoBehaviour
{
    private int energy;
    private int maxEnergy = 120;
    private int prevEnergy;

    private void Awake()
    {
        energy = maxEnergy;
        prevEnergy = maxEnergy;
    }

    public bool DecreaseEnergy(int amount)
    {
        if (energy >= amount)
        {
            energy -= amount;
            return true;
        }

        return false;
    }

    public void IncreaseEnergy(int amount)
    {
        energy += amount;
        if (energy > maxEnergy)
        {
            energy = maxEnergy;
        }
    }

    public void IncreaseMaxEnergy(int amount)
    {
        maxEnergy += amount;
    }

    public void IncreaseMaxEnergyByPercentage(float percentage)
    {
        maxEnergy = (int)(maxEnergy * (1 + percentage));
    }

    public void SaveEnergy()
    {
        prevEnergy = energy;
    }

    public void ReloadEnergy()
    {
        energy = prevEnergy;
    }
}
