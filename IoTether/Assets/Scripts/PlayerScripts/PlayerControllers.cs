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

    private Vector3 mousePos;

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
        if (GameManager.manager.gameIsPaused)
        {
            return;
        }

        Vector3 vect3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
        mousePos = Camera.main.ScreenToWorldPoint(vect3);

        // Get movement input
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical"); 

        // Flip sprite based on mouse position
        if (mousePos.x < transform.position.x && facingRight)
        {
            Flip();
        }
        else if (mousePos.x > transform.position.x && !facingRight)
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
