using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int damage;

    [SerializeField]
    protected GameObject player;

    protected Animator animator;
    protected Rigidbody2D rb;
    private SpriteRenderer sr;

    private Material matWhite;
    private Material matDefault;

    private float distance;
    private bool facingRight = true;

    protected void Start()
    {
        Init();
    }

    protected virtual void Init() // can be overridden from derived classes
    {
        player = GameObject.FindGameObjectWithTag("Player");
        GetComponent<AIDestinationSetter>().target = player.transform;

        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();

        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = sr.material;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
            damageable.DecreaseHealth(damage);
        }
    }

    protected virtual void Update()
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

        /*
        if (distance < 10)
        {
            // Move towards player if close enough to player
            transform.position = Vector2.MoveTowards(transform.position, 
                               player.transform.position, 
                               speed * Time.deltaTime);
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
        */
    }

    protected void Flip()
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
            Invoke("ResetMaterial", 0.1f);
        }
    }

    private void KillSelf()
    {
        Destroy(gameObject);
        GameManager.manager.IncreaseScore(1);
    }

    private void ResetMaterial()
    {
        sr.material = matDefault;
    }
}
