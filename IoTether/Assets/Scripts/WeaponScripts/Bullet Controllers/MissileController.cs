using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    public int Damage { get; set; }
    private Transform target;
    private Rigidbody2D rb;

    private float speed = 3f;
    private float rotateSpeed = 200f;

    public GameObject ImpactEffect;

    public static GameObject Create(GameObject missilePrefab, Transform firePoint, int damage)
    {
        GameObject missile = GameObject.Instantiate(missilePrefab, firePoint.position, firePoint.rotation);
        MissileController missileController = missile.GetComponent<MissileController>();
        missileController.Damage = damage;
        return missile;
    }

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();

        Invoke("Impact", 5f);
    }

    private void FixedUpdate()
    {
        Vector2 direction = (Vector2)target.position - rb.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;
        rb.velocity = transform.up * speed;
    }

    public void Impact()
    {
        Destroy(gameObject);
        Instantiate(ImpactEffect, transform.position, transform.rotation);
    }

    public bool CanImpact(Collider2D collision)
    {
        return collision.gameObject.tag != "Props"
           && collision.gameObject.tag != "Bullet"
           && collision.gameObject.tag != "Ignore"
           && collision.gameObject.tag != "CrystalCollide"
           && collision.gameObject.tag != "Enemy";
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            IDamageable damageable = collision.transform.parent.gameObject.GetComponent<IDamageable>();
            Impact();
            damageable.DecreaseHealth(Damage);
        }
        else if (CanImpact(collision))
        {
            Impact();
        }
    }
}
