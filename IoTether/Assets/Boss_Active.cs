using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Active : StateMachineBehaviour
{
    public GameObject projectile;
    protected Transform firePoint;
    public float projectileSpeed;
    public float fireRate;
    private float nextFire = 0.1f;
    public float range;

    private GameObject curr;
    private GameObject player;

    private int damage;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        curr = animator.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        firePoint = curr.transform.Find("FirePoint");
        damage = curr.GetComponent<Enemy>().damage;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distanceToPlayer = Vector2.Distance(curr.transform.position, player.transform.position);

        if (distanceToPlayer < range && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    private void Shoot()
    {
        GameObject bullet = EnemyBulletController.Create(projectile, firePoint, damage);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce((player.transform.position - curr.transform.position).normalized * projectileSpeed, ForceMode2D.Impulse);
        // Play audio?
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
