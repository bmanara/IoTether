using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    public Sprite[] spikeSprites;
    public float primeInterval = 1f;
    public float activeInterval = 0.1f;
    public float cooldownInterval = 0.1f;


    //public float changeInterval = 2f;
    //public float fastInterval = 1f;


    public int damage;
    public float damageCooldown = 1f;
    public float startDelay = 0f;

    private SpriteRenderer spriteRenderer;
    private int currentSpriteIndex = 0;
    private bool canDamage = false;
    public static bool onCooldown = false;

    //HashSet to track Colliders in Contact
    private HashSet<Collider2D> collidersInContact = new HashSet<Collider2D>();


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(StartWithDelay());
    }

    IEnumerator StartWithDelay()
    {
        yield return new WaitForSeconds(startDelay);
        StartCoroutine(ChangeSprite());
    }

 
    /*

    IEnumerator ChangeSprite()
    {
        while (true)
        {
            currentSpriteIndex = (currentSpriteIndex + 1) % spikeSprites.Length;
            spriteRenderer.sprite = spikeSprites[currentSpriteIndex];
            canDamage = (currentSpriteIndex >= spikeSprites.Length - 2); // Set canDamage true only on the 3rd and 4th sprite

            if (canDamage)
            {
                DamageAllInContact();
            }

            float currentInterval = (currentSpriteIndex >= spikeSprites.Length - 2) ? fastInterval : changeInterval;
            yield return new WaitForSeconds(currentInterval);
        }
    }
    */ 

    IEnumerator ChangeSprite()
    {
        while (true)
        {
            spriteRenderer.sprite = spikeSprites[0];
            canDamage = false;
            yield return new WaitForSeconds(primeInterval);

            spriteRenderer.sprite = spikeSprites[1];
            canDamage = true;
            DamageAllInContact();
            yield return new WaitForSeconds(activeInterval);

            spriteRenderer.sprite = spikeSprites[2];
            canDamage = true;
            DamageAllInContact();
            yield return new WaitForSeconds(activeInterval);

            spriteRenderer.sprite = spikeSprites[3];
            canDamage = false;
            yield return new WaitForSeconds(cooldownInterval);

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!collidersInContact.Contains(other))
        {
            collidersInContact.Add(other);
        }
        TryDamagePlayer(other);
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        TryDamagePlayer(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(collidersInContact.Contains(other))
        {
            collidersInContact.Remove(other);

        }
    }

    private void TryDamagePlayer(Collider2D other)
    {
        if (canDamage
            && !onCooldown
            && other.gameObject.tag == "Player"
            && other.gameObject.name == "Player")
        {
            // Damage the player
            GameObject playerParent = other.gameObject.transform.parent.gameObject;
            IDamageable damageable = playerParent.GetComponent<IDamageable>();
            damageable.DecreaseHealth(damage);
            StartCooldown();
        }
    }

    private void DamageAllInContact()
    {
        foreach (var collider in collidersInContact)
        {
            if (collider != null)
            {
                TryDamagePlayer(collider);
            }
        }
    }

   public void StartCooldown()
    {
        StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        onCooldown = true;
        yield return new WaitForSeconds(damageCooldown);
        onCooldown = false;

    }


}
