using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeleeWeapon : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    protected float attackSpeed;
    protected float delay;
    protected int damage;
    protected float force;
    protected bool isAttacking = false;

    private float timeUntilMelee = 0.1f;

    protected void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > timeUntilMelee)
        {
            isAttacking = true;
            animator.SetTrigger("Attack"); // attack animation + moving BoxCollider2D
            timeUntilMelee = Time.time + delay;
            Invoke("ResetAttack", attackSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isAttacking && collision.gameObject.tag == "Enemy")
        {
            IDamageable damageable = collision.GetComponent<IDamageable>();
            Vector2 direction = (collision.transform.position - transform.position).normalized;
            Vector2 knockback = direction * force;

            damageable.DecreaseHealth(damage, knockback);
        }
    }

    private void ResetAttack()
    {
        isAttacking = false;
    }
}
