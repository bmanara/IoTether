using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpeedPerk", menuName = "Perks/SpeedPerk")]
public class SpeedPerk : IPerk
{
    public float Speed;

    public override void Apply(GameObject target)
    {
        GameObject playerParent = target.transform.parent.gameObject;
        playerParent.GetComponent<PlayerControllers>().IncreaseMoveSpeed(Speed);
    }
}
