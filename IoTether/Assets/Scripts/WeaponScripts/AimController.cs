using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
    private Vector3 mousePos;

    public Transform player;
    private bool meleeWeapon;

    private void Update()
    {
        if (GameManager.manager.gameIsPaused)
        {
            return;
        }

        // Flip weapon sprite based on mouse position
        if (mousePos.x < transform.position.x)
        {
            if (meleeWeapon)
            {
                GetComponentInChildren<SpriteRenderer>().flipX = true;
            }
            else
            {
                GetComponentInChildren<SpriteRenderer>().flipY = true;
            }
        }
        else
        {
            if (meleeWeapon)
            {
                GetComponentInChildren<SpriteRenderer>().flipX = false;
            }
            else
            {
                GetComponentInChildren<SpriteRenderer>().flipY = false;
            }
        }

        // Rotate game object based on mouse position
        Vector3 vect3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
        mousePos = Camera.main.ScreenToWorldPoint(vect3);

        Vector3 rotation = mousePos - transform.position;
        float angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        transform.position = player.transform.position - new Vector3(0, 0.65f, 0);
    }

    public void UseMeleeWeapon()
    {
        meleeWeapon = true;
    }

    public void UseRangedWeapon()
    {
        meleeWeapon = false;
    }
}
