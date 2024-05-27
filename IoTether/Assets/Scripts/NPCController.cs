using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    private bool facingRight = true;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        // Flip sprite based on player position
        if (facingRight &&
            transform.position.x > player.transform.position.x)
        {
            Flip();
        } 
        else if (!facingRight &&
                 transform.position.x < player.transform.position.x)
        {
            Flip();
        }
    }

    private void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
        facingRight = !facingRight;
    }
}
