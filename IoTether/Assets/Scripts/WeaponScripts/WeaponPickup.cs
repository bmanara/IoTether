using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public GameObject weaponToGive;
    private bool ableToPickup = false;
    private Collider2D other;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ableToPickup = true;
            other = collision;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ableToPickup = false;
        }
    }

    private void Update()
    {
        if (ableToPickup && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Pressing E");
            other.GetComponent<WeaponSwap>().UpdateWeapon(weaponToGive);
            Destroy(gameObject);
        }
    }

    /*
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E) && collision.CompareTag("Player")) {
            Debug.Log("Pressing E");
            collision.GetComponent<WeaponSwap>().UpdateWeapon(weaponToGive);
            Destroy(gameObject);
        }
    }
    */
}
