using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public int weaponToGive;
    private bool ableToPickup = false;
    private Collider2D other;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Hitbox")
        {
            ableToPickup = true;
            other = collision;
            UIManager.manager.EnablePickUpPanel();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Hitbox")
        {
            ableToPickup = false;
            UIManager.manager.DisablePickUpPanel();
        }
    }

    private void Update()
    {
        if (ableToPickup && Input.GetKeyDown(KeyCode.E))
        {
            bool status = other.transform.parent.GetComponentInChildren<WeaponSwitching>().SwapWeapon(weaponToGive);
            AudioManager.manager.PlaySFX("PickUp");
            if (status)
            {
                Destroy(gameObject);
            }
        }
    }

}
