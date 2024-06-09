using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDrop : MonoBehaviour
{
    public GameObject weaponToDrop;

    public void DropWeapon(Vector3 pos)
    {
        Instantiate(weaponToDrop, pos, Quaternion.identity);
    }
}
