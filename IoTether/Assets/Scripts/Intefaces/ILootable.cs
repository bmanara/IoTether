using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILootable
{
    // Amount dropped determined in Enemy.cs
    public void DropEnergy();
    public void DropHealth();
}
