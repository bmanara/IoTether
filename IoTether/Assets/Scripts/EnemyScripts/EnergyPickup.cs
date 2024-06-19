using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerEnergy player = collision.transform.parent.GetComponent<PlayerEnergy>();
            player.IncreaseEnergy(1);
            Destroy(gameObject);
        }
    }
}
