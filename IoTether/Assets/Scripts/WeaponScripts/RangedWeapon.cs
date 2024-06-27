using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangedWeapon : MonoBehaviour
{
    protected Transform firePoint;
    [SerializeField]
    public GameObject bulletPrefab;

    protected float bulletForce;
    protected float fireRate;
    protected float canFire;
    protected int energyCost;
    protected int damage;
    protected float force;

    protected void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        firePoint = transform.Find("FirePoint");
    }

    protected virtual void Update()
    {
        if (GameManager.manager.gameIsPaused)
        {
            return;
        }

        if (Input.GetButtonDown("Fire1") && Time.time > canFire)
        {
            Shoot();
            canFire = Time.time + fireRate;
        }
    }

    public void Shoot()
    {
        bool canShoot = PlayerControllers.Instance.GetComponent<PlayerEnergy>().DecreaseEnergy(energyCost);
        if (canShoot)
        {
            GameObject bullet = PlayerBulletController.Create(bulletPrefab, firePoint, damage, force);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
            GetComponent<AudioSource>().Play();
        }
    }

    // TESTING PURPOSES
    public void SetFirePoint()
    {
        firePoint = transform.Find("FirePoint");
    }
}
