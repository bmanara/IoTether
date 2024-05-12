using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    private Vector3 mousePos;

    public Transform player;

    private void Update()
    {
        // Flip gun sprite based on mouse position
        if (mousePos.x < transform.position.x)
        {
            GetComponentInChildren<SpriteRenderer>().flipY = true;
        }
        else
        {
            GetComponentInChildren<SpriteRenderer>().flipY = false;
        }

        Vector3 vect3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
        mousePos = Camera.main.ScreenToWorldPoint(vect3);
        Debug.Log("Running" + mousePos);

        Vector3 rotation = mousePos - transform.position;
        float angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        transform.position = player.transform.position - new Vector3(0, 0.65f, 0);
    }
}
