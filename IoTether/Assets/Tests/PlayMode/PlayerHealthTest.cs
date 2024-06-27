using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerHealthTest
{
    GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/PlayerParent.prefab");

    [Test]
    public void TakeDamage()
    {
        var player = Object.Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        int initialHealth = player.GetComponent<PlayerHealth>().GetHealth();
        player.GetComponent<PlayerHealth>().DecreaseHealth(2);

        Assert.AreEqual(player.GetComponent<PlayerHealth>().GetHealth(), initialHealth - 2);
    }

    [Test]
    public void TakeDamageAndHeal()
    {
        // Use the Assert class to test conditions
        var player = Object.Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        int initialHealth = player.GetComponent<PlayerHealth>().GetHealth();
        player.GetComponent<PlayerHealth>().DecreaseHealth(1);

        Assert.AreEqual(player.GetComponent<PlayerHealth>().GetHealth(), initialHealth - 1);
        player.GetComponent<PlayerHealth>().Heal(1);

        Assert.AreEqual(player.GetComponent<PlayerHealth>().GetHealth(), initialHealth);
    }
}
