using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable, ILootable
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int damage;
    protected int energyDrop;
    protected int healthDrop;

    [SerializeField]
    protected GameObject player;

    public GameObject energyDropPrefab;
    public GameObject healthDropPrefab;

    protected Rigidbody2D rb;
    private SpriteRenderer sr;
    public AstarAI ai;

    private Material matWhite;
    private Material matDefault;

    private float distance;
    private bool facingRight = true;
    private float dropForce = 5f;

    protected void Start()
    {
        Init();
    }

    protected virtual void Init() // can be overridden from derived classes
    {
        player = GameObject.FindGameObjectWithTag("Player");

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        ai = GetComponent<AstarAI>();

        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = sr.material;
    }

    // change to onTriggerEnter2D? since hitbox is trigger
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
        Vector2 direction = player.transform.position - transform.position;

        if (direction.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (direction.x < 0 && facingRight)
        {
            Flip();
        }
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
        DropEnergy();
        Destroy(gameObject);
        GameManager.manager.IncreaseScore(1);
    }

    private void ResetMaterial()
    {
        sr.material = matDefault;
    }

    public void DropEnergy()
    {
        for (int i = 0; i < energyDrop; i++)
        {
            GameObject energy = Instantiate(energyDropPrefab, transform.position, Quaternion.identity);
            float randomX = Random.Range(-1f, 1f);
            float randomY = Random.Range(-1f, 1f);

            Vector2 randDir = new Vector2(randomX, randomY);
            Rigidbody2D rb = energy.GetComponent<Rigidbody2D>();
            rb.AddForce(randDir * dropForce, ForceMode2D.Impulse);
        }
    }

    public void DropHealth()
    {
        throw new System.NotImplementedException();
    }
}
