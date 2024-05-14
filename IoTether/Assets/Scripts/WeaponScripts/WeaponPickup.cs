using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public GameObject weaponToGive;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            // Add UI to show player that they can pick up the weapon
            if (Input.GetKeyDown(KeyCode.E))
            {
                collision.GetComponent<WeaponSwap>().UpdateWeapon(weaponToGive);
                Destroy(gameObject);
            }
        }
    }
}
