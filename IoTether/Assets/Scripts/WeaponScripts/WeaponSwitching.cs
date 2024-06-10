using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    private int primaryWeapon;
    private int secondaryWeapon;
    private int equippedWeapon;

    // Checkpoint save
    private int savedPrimaryWeapon;
    private int savedSecondaryWeapon;

    private void Start()
    {
        // Start with default weapons
        primaryWeapon = 0;
        secondaryWeapon = 1;

        SelectPrimaryWeapon();
        equippedWeapon = primaryWeapon;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectPrimaryWeapon();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectSecondaryWeapon();
        }
    }

    private int SelectPrimaryWeapon()
    {
        int i = 0;
        int result = 0;
        equippedWeapon = primaryWeapon;
        foreach (Transform weapon in transform)
        {
            if (i == primaryWeapon)
            {
                weapon.gameObject.SetActive(true);
                result = i;
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }

            i++;
        }
        return result;
    }

    private int SelectSecondaryWeapon()
    {
        int i = 0;
        int result = 0;
        equippedWeapon = secondaryWeapon;
        foreach (Transform weapon in transform)
        {
            if (i == secondaryWeapon)
            {
                weapon.gameObject.SetActive(true);
                result = i;
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }

            i++;
        }
        return result;
    }

    public bool SwapWeapon(int newWeapon)
    {
        if (newWeapon == primaryWeapon || newWeapon == secondaryWeapon)
        {
            // Shouldn't be able to pick up the same weapon
            return false;
        }

        if (equippedWeapon == primaryWeapon)
        {
            transform.GetChild(primaryWeapon).GetComponent<WeaponDrop>().DropWeapon(transform.position);
            primaryWeapon = newWeapon;
            SelectPrimaryWeapon();
        }
        else
        {
            transform.GetChild(secondaryWeapon).GetComponent<WeaponDrop>().DropWeapon(transform.position);
            secondaryWeapon = newWeapon;
            SelectSecondaryWeapon();
        }

        return true;
    }

    public void SaveWeapons()
    {
        savedPrimaryWeapon = primaryWeapon;
        savedSecondaryWeapon = secondaryWeapon;
    }

    public void LoadWeapons()
    {
        primaryWeapon = savedPrimaryWeapon;
        secondaryWeapon = savedSecondaryWeapon;
        SelectPrimaryWeapon();
    }
}
