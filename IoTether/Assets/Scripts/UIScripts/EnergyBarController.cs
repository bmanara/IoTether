using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBarController : MonoBehaviour
{
    public Slider slider;

    public void SetMaxEnergy(int maxEnergy)
    {
        slider.maxValue = maxEnergy;
    }

    public void SetEnergy(int energy)
    {
        slider.value = energy;
    }
}
