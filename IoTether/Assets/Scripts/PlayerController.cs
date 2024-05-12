using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 4f;
    private bool facingRight = true;

    private Vector2 input;
    public Rigidbody2D rbPlayer;
    public Animator animator;

    private void Update()
    {
        // Get movement input
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        // Flip sprite based on movement direction
        if (input.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (input.x < 0 && facingRight)
        {
            Flip();
        }

        // Update animator parameters
        if (input != Vector2.zero)
        {
            animator.SetBool("isMoving", true);
        } 
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    private void FixedUpdate()
    {
        // Movement logic
        rbPlayer.MovePosition(rbPlayer.position + input * moveSpeed * Time.fixedDeltaTime);
    }

    private void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
    }
}
