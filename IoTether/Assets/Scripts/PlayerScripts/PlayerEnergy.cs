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
        UpdateEnergyBar();
    }

    public void ReloadEnergy()
    {
        energy = prevEnergy;
        UpdateEnergyBar();
    }

    public void UpdateEnergyBar()
    {
        UIManager.manager.SetEnergy(energy, maxEnergy);
    }
}
