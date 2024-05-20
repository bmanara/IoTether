using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageable
{
    private GameObject player;
    public Animator animator;
    public Rigidbody2D rb;
    private Material matWhite;
    private Material matDefault;
    private SpriteRenderer sr;

    public int health;
    public float speed;

    private float distance;
    private bool facingRight = true;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sr = gameObject.GetComponent<SpriteRenderer>();
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material; // as Material is type casting
        matDefault = sr.material;
    }

    private void Update()
    {
        // Get distance from enemy to player
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        if (direction.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (direction.x < 0 && facingRight)
        {
            Flip();
        }

        if (distance < 10)
        {
            // Move towards player if close enough to player
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    private void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
    }

    public void DecreaseHealth(int damage)
    {
        OnHit(damage);
    }

    public void DecreaseHealth(int damage, Vector2 knockback)
    {
        OnHit(damage);

        // Apply knockback
        rb.AddForce(knockback, ForceMode2D.Impulse);
    }

    private void OnHit(int damage)
    {
        sr.material = matWhite;
        health = health - damage;
        if (health <= 0)
        {
            KillSelf();
        }
        else
        {
            Invoke("ResetMaterial", .1f);
        }
    }

    private void KillSelf()
    {
        // TODO: Add death animation here
        Destroy(gameObject);
    }

    void ResetMaterial()
    {
        sr.material = matDefault;
    }
}
