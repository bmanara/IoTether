using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMovement : MonoBehaviour
{
    public Sprite[] spikeSprites;
    public float changeInterval = 2f;
    public int damage;

    private SpriteRenderer spriteRenderer;
    private int currentSpriteIndex = 0;
    private bool canDamage = false;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        if (canDamage 
            && other.gameObject.tag == "Player" 
            && other.gameObject.name == "Hitbox")
        {
            // Damage the player
            GameObject playerParent = other.gameObject.transform.parent.gameObject;
            IDamageable damageable = playerParent.GetComponent<IDamageable>();
            damageable.DecreaseHealth(damage);
        }
    }


}
