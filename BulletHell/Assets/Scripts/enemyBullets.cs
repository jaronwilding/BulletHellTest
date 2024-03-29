﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullets : Bullet
{
    // Start is called before the first frame update
    protected override void OnCollisionEnter2D(Collision2D cold)
    {
        
        Collider2D col = cold.collider;
        if(col != null && col.tag == "Player")
        {
            col.SendMessage("ApplyDamage", 1.0f);
            DestroyObject();
        }
    }
}
