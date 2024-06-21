using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBulletController
{
    int Damage { get; set; }

   
    void Impact();
    bool CanImpact(Collider2D collision);

    void OnTriggerEnter2D(Collider2D collision);
}
