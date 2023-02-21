using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2_BasicAttack : Weapon
{
    protected override void Start() {
        baseDamage = 2f;
        damageMultiplier = 1;
        fireRate = 10;
        
        numProjectiles = 1;
        angles = new float[] {0};
        numAngles = 1;
        
        playerDamageMultiplier = 1;

        base.Start();
    }
}
