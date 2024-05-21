using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMovement : MonoBehaviour
{
    public Sprite[] spikeSprites;
    public float changeInterval = 2f;

    private SpriteRenderer spriteRenderer;
    private int currentSpriteIndex = 0;
    private Vector3 startPos;
    private bool canDamage = false;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startPos = transform.position;
        InvokeRepeating("ChangeSprite", changeInterval, changeInterval);
    }

  

    void ChangeSprite()
    {
        currentSpriteIndex = (currentSpriteIndex + 1) % spikeSprites.Length;
        spriteRenderer.sprite = spikeSprites[currentSpriteIndex];

        canDamage = (currentSpriteIndex == spikeSprites.Length - 1); // Set canDamage true only on the 4th sprite
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canDamage && other.CompareTag("Player"))
        {
            // Damage the player
            Debug.Log("Player damaged!");
            // add code to damage the player
        }
    }

}
