using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aura : Weapon
{
    protected override void Start() {

        baseDamage = 0.5f;
        damageMultiplier = 1f;
        fireRate = 1;

        numProjectiles = 1;
        angles = new float[] {0};
        numAngles = 1;

        playerDamageMultiplier = 1; //Remove

        name = "Aura";

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
                currProj.transform.localScale = new Vector3(currProj.transform.localScale.x + 1, currProj.transform.localScale.y + 1, currProj.transform.localScale.z);
                break;
            case 3:
                currProj.transform.localScale = new Vector3(currProj.transform.localScale.x + 1, currProj.transform.localScale.y + 1, currProj.transform.localScale.z);
                break;
            default:
                break;
        }

        base.ChangeStats();
    }
}
