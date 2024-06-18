using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public IPerk perk;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.name == "Player")
        {
            Destroy(gameObject);
            perk.Apply(collision.gameObject);
        }
    }
}
