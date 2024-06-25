using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
    private Vector3 mousePos;
    private bool facingRight = true;

    public Transform player;
    private bool meleeWeapon;

    private void Update()
    {
        // Get mouse position
        Vector3 vect3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
        mousePos = Camera.main.ScreenToWorldPoint(vect3);

        if (GameManager.manager.gameIsPaused)
        {
            return;
        }

        if (meleeWeapon)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            // Do not rotate when using melee weapon
            if (mousePos.x < transform.position.x && facingRight)
            {
                FlipMeleeWeapon();
            }
            else if (mousePos.x > transform.position.x && !facingRight)
            {
                FlipMeleeWeapon();
            }
            return;
        }
        
        FlipRangedWeapon();

        // Rotate game object based on mouse position

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

    private void FlipMeleeWeapon()
    {
        // Flip melee weapon sprite based on mouse position
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
        facingRight = !facingRight;
    }

    private void FlipRangedWeapon()
    {
        if (!facingRight)
        {
            Vector3 currentScale = transform.localScale;
            currentScale.x *= -1;
            transform.localScale = currentScale;
            facingRight = !facingRight;
        }

        // Flip gun sprite based on mouse position
        if (mousePos.x < transform.position.x)
        {
            GetComponentInChildren<SpriteRenderer>().flipY = true;
        }
        else
        {
            GetComponentInChildren<SpriteRenderer>().flipY = false;
        }
    }
}
