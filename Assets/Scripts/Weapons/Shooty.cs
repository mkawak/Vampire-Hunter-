using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Shooty : Weapon
{
    protected override void Start() {

        baseDamage = 0.5f;
        damageMultiplier = 1f;
        fireRate = 60;

        numProjectiles = 6;
        angles = new float[] {0, 60f, 120f, 180f, 240f, 300f};
        numAngles = 6;

        playerDamageMultiplier = 1; //Remove

        name = "shooty";

        base.Start();
    }

    public override void Fire() {
        base.Fire();
        for (int i = 0; i < numAngles; i++) {
            if (angles[i] >= 360) {
                angles[i] -= 360;
            }
            angles[i] += 30;
        }
    }

    new void Update() {
        //base.Update();

        timeTillShot -= Time.deltaTime;

        if (timeTillShot <= 0) {
            if (autoFire) {
                timeTillShot = 60/fireRate;
                Fire();
            }
            else if (Input.GetKeyDown(keycode)) {
                timeTillShot = 60/fireRate;
                Fire();
            }
        }

        if (coolDown != null) CoolDown();
    }

    protected override void ChangeStats() {
        Debug.Log(level);
        switch(level) {
            case 2:
                break;
            case 3:
                break;
            default:
                break;
        }

        base.ChangeStats();
    }
}
