using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedPerk : MonoBehaviour
{
    public IPerk perk;

    public string perkText;

    public Color32 color;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.name == "Player")
        {
            Destroy(gameObject);
            perk.Apply(collision.gameObject);

            UIManager.manager.PlayAdaptiveText(perkText, color, 0.7f, 0.3f);
        }
    }
}
