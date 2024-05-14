using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwap : MonoBehaviour
{
    public Transform weaponSlot;
    public GameObject activeWeapon;
    private GameObject currWeapon;

    private void Start()
    {
        GameObject weapon = Instantiate(activeWeapon, weaponSlot.transform.position, weaponSlot.transform.rotation);
        currWeapon = weapon;
        weapon.transform.parent = weaponSlot.transform;
    }

    public void UpdateWeapon(GameObject newWeapon)
    {
        currWeapon.GetComponent<WeaponDrop>().dropWeapon(weaponSlot.transform.position);
        Destroy(currWeapon);

        activeWeapon = newWeapon;

        GameObject weapon = Instantiate(activeWeapon, 
            weaponSlot.transform.position,
            weaponSlot.transform.rotation);
        currWeapon = weapon;
        weapon.transform.parent = weaponSlot.transform;
    }
}
