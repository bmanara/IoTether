using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllers : MonoBehaviour
{
    private float moveSpeed = 4f;
    private bool facingRight = true;

    private Vector2 input;
    public Rigidbody2D rbPlayer;
    public Animator animator;
    public static PlayerControllers Instance;

    private void Start()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
        Instance = null;
    }


    // Update is called once per frame
    void Update()
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
        rbPlayer.MovePosition(rbPlayer.position + input * moveSpeed * Time.fixedDeltaTime);
    }

    private void Flip()
    {
        GameObject child = transform.GetChild(1).gameObject;
        Vector3 currentScale = child.transform.localScale;
        currentScale.x *= -1;
        child.transform.localScale = currentScale;
        facingRight = !facingRight;
    }

    public void Respawn(Vector3 spawnPoint)
    {
        transform.position = spawnPoint;
    }
}
