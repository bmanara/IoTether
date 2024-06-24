using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class PerkButton : MonoBehaviour
{
    public GameObject droppedPerk;
    private GameObject player;
    private IPerk perk;

    private void Start()
    {
        player = GameObject.Find("Player");
        perk = droppedPerk.GetComponent<IPerk>();
    }

    [ContextMenu("Apply Perk")]
    void Apply()
    {
        if (perk != null)
        {
            perk.Apply(player);
        }
    }
}
