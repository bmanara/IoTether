using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergy : MonoBehaviour
{
    private int energy;
    private int maxEnergy = 150;
    private int prevEnergy;
    private int prevMaxEnergy;

    private void Awake()
    {
        energy = maxEnergy;
        prevEnergy = maxEnergy;
        prevMaxEnergy = maxEnergy;

        UpdateEnergyBar();
    }

    public bool DecreaseEnergy(int amount)
    {
        if (energy >= amount)
        {
            energy -= amount;
            UpdateEnergyBar();
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

        UpdateEnergyBar();
    }

    public void IncreaseMaxEnergy(int amount)
    {
        maxEnergy += amount;
        UpdateEnergyBar();
    }

    public void IncreaseMaxEnergyByPercentage(float percentage)
    {
        maxEnergy = (int)(maxEnergy * (1 + percentage));
        UpdateEnergyBar();
    }

    public void replenishEnergy()
    {
        IncreaseEnergy(maxEnergy);
        UpdateEnergyBar();
    }

    public void SaveEnergy()
    {
        prevEnergy = energy;
        prevMaxEnergy = maxEnergy;
        UpdateEnergyBar();
    }

    public void ReloadEnergy()
    {
        energy = prevEnergy;
        maxEnergy = prevMaxEnergy;
        UpdateEnergyBar();
    }

    public void UpdateEnergyBar()
    {
        if (UIManager.manager != null)
        {
            UIManager.manager.SetEnergy(energy, maxEnergy);
        }
       
    }

    // For testing purposes
    public int GetEnergy()
    {
        return energy;
    }
}
