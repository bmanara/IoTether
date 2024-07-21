using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BulletController : MonoBehaviour
{
    public int Damage { get; set; }

    public GameObject ImpactEffect;

   
    public void Impact()
    {
        Destroy(gameObject);
        Instantiate(ImpactEffect, transform.position, transform.rotation);
    }

    public virtual bool CanImpact(Collider2D collision)
    {
        return collision.gameObject.tag != "Props"
           && collision.gameObject.tag != "Bullet"
           && collision.gameObject.tag != "Ignore"
           && collision.gameObject.tag != "CrystalCollide";
    }

    abstract public void OnTriggerEnter2D(Collider2D collision);
}
