using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon1 : Weapon
{
    protected override void Start() {

        baseDamage = 1;
        damageMultiplier = 1.2f;
        fireRate = 60;

        numProjectiles = 3;
        angles = new float[] {0, -30f, 30f};
        numAngles = 3;

        playerDamageMultiplier = 1; //Remove

        base.Start();
    }

    public override void Fire() {
        base.Fire();
    }

    new void Update() {
        base.Update();
        // if (Input.GetKeyDown(KeyCode.Alpha1)) Fire();
    }
}
