using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazor : Weapon
{
    protected override void Start() {

        baseDamage = 0.5f;
        damageMultiplier = 1f;
        fireRate = 1;

        numProjectiles = 1;
        angles = new float[] {0};
        numAngles = 1;

        playerDamageMultiplier = 1; //Remove

        base.Start();
    }

    bool fired = false;
    public override void Fire() {
        if (fired) return;
        base.Fire();
        fired = true;
    }

    new void Update() {
        base.Update();
        // if (Input.GetKeyDown(KeyCode.Alpha2)) Fire();
    }

    protected override void ChangeStats() {
        switch(level) {
            case 2:
                baseDamage = 5f;
                break;
            case 3:
                Destroy(currProj.gameObject);
                numProjectiles = 3;
                angles = new float[] {0, 120f, 240f};
                numAngles = 3;
                fired = false;
                Fire();
                break;
            default:
                break;
        }

        base.ChangeStats();
    }
}
