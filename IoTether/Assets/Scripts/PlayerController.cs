using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 2f;

    private Vector2 input;
    public Rigidbody2D rbPlayer;
    public Animator animator;

    private void Update()
    {
        // Get movement input
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        // Movement logic
        rbPlayer.MovePosition(rbPlayer.position + input * moveSpeed * Time.fixedDeltaTime);
    }
}
