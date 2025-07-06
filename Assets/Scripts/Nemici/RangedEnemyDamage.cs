using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyDamage : EnemyDamage
{
    private new void OnTriggerEnter2D(Collider2D collision)
    {
        //disattiva su collisione
        base.OnTriggerEnter2D(collision);
    }
}
