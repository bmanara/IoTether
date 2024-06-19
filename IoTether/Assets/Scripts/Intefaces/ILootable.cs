using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILootable
{
    // Amount dropped determined in Enemy.cs
    public void DropAmmo();
    public void DropHealth();
}
