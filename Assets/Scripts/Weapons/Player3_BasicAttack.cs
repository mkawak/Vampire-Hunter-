using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3_BasicAttack : Weapon
{
    protected override void Start() {

        baseDamage = 2f;
        damageMultiplier = 1.2f;
        fireRate = 80;

        numProjectiles = 1;
        angles = new float[] {0};
        numAngles = 1;

        playerDamageMultiplier = 1; //Remove

        base.Start();
    }

    public override void Fire() {
        base.Fire();
    }

    new void Update() {
        base.Update();
    }
}
