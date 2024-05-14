using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleController : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    private float bulletForce = 15f;
    private float fireRate = 0.2f;
    private float canFire = 0.1f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > canFire)
        {
            Shoot();
            canFire = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        GetComponent<AudioSource>().Play();
    }
}
