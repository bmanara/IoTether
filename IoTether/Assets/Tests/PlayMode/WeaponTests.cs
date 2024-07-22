using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

public class WeaponTests
{
    GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/PlayerParent.prefab");

    [SetUp]
    public void Setup()
    {
        var player = Object.Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        player.GetComponent<PlayerControllers>().GetInstance();
    }

    [Test]
    public void PistolTests()
    {
        var player = Object.Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        player.GetComponentInChildren<WeaponSwitching>().SwapWeapon(1);
        
        RangedWeapon rangedWeapon = player.transform.GetChild(0).GetComponentInChildren<RangedWeapon>();
        GameObject firePoint = new GameObject();
        firePoint.name = "FirePoint";
        firePoint.transform.parent = rangedWeapon.gameObject.transform;
        rangedWeapon.SetFirePoint();
        int initialEnergy = player.GetComponent<PlayerEnergy>().GetEnergy();
        
        rangedWeapon.Shoot();
    }

    [Test]
    public void SMGTests()
    {
        var player = Object.Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        player.GetComponentInChildren<WeaponSwitching>().SwapWeapon(2);

        RangedWeapon rangedWeapon = player.transform.GetChild(0).GetComponentInChildren<RangedWeapon>();
        GameObject firePoint = new GameObject();
        firePoint.name = "FirePoint";
        firePoint.transform.parent = rangedWeapon.gameObject.transform;
        rangedWeapon.SetFirePoint();
        int initialEnergy = player.GetComponent<PlayerEnergy>().GetEnergy();

        rangedWeapon.Shoot();
    }

    [Test]
    public void RifleTests()
    {
        var player = Object.Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        player.GetComponentInChildren<WeaponSwitching>().SwapWeapon(3);

        RangedWeapon rangedWeapon = player.transform.GetChild(0).GetComponentInChildren<RangedWeapon>();
        GameObject firePoint = new GameObject();
        firePoint.name = "FirePoint";
        firePoint.transform.parent = rangedWeapon.gameObject.transform;
        rangedWeapon.SetFirePoint();
        int initialEnergy = player.GetComponent<PlayerEnergy>().GetEnergy();

        rangedWeapon.Shoot();
    }

    [Test]

    public void SniperTests()
    {
        var player = Object.Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        player.GetComponentInChildren<WeaponSwitching>().SwapWeapon(4);

        RangedWeapon rangedWeapon = player.transform.GetChild(0).GetComponentInChildren<RangedWeapon>();
        GameObject firePoint = new GameObject();
        firePoint.name = "FirePoint";
        firePoint.transform.parent = rangedWeapon.gameObject.transform;
        rangedWeapon.SetFirePoint();
        int initialEnergy = player.GetComponent<PlayerEnergy>().GetEnergy();

        rangedWeapon.Shoot();
    }

    [Test]

    public void BurstRifleTests()
    {
        var player = Object.Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        player.GetComponentInChildren<WeaponSwitching>().SwapWeapon(5);

        RangedWeapon rangedWeapon = player.transform.GetChild(0).GetComponentInChildren<RangedWeapon>();
        GameObject firePoint = new GameObject();
        firePoint.name = "FirePoint";
        firePoint.transform.parent = rangedWeapon.gameObject.transform;
        rangedWeapon.SetFirePoint();
        int initialEnergy = player.GetComponent<PlayerEnergy>().GetEnergy();

        rangedWeapon.Shoot();
    }

    [Test]

    public void ShotgunTests()
    {
        var player = Object.Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        player.GetComponentInChildren<WeaponSwitching>().SwapWeapon(6);

        RangedWeapon rangedWeapon = player.transform.GetChild(0).GetComponentInChildren<RangedWeapon>();
        GameObject firePoint = new GameObject();
        firePoint.name = "FirePoint";
        firePoint.transform.parent = rangedWeapon.gameObject.transform;
        rangedWeapon.SetFirePoint();
        int initialEnergy = player.GetComponent<PlayerEnergy>().GetEnergy();

        rangedWeapon.Shoot();
    }
}
