using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3_BasicAttack : Weapon
{
    protected override void Start() {

        baseDamage = 2f;
        damageMultiplier = 1.2f;
        fireRate = 10;

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
        timeTillShot -= Time.deltaTime;

        if (timeTillShot <= 0) {
            if (autoFire) {
                timeTillShot = 60/fireRate;
                Fire();
            }
            else if (Input.GetKeyDown(keycode)) {
                timeTillShot = 60/fireRate;
                AudioManager.Instance.PlaySFX("SemiCircleSFX");
                Fire();
            }
        }

        if (coolDown != null) CoolDown();
    }

    protected override void ChangeStats() {
        switch(level) {
            case 2:
                fireRate = 30;
                break;
            case 3:
                fireRate = 60;
                break;
            default:
                break;
        }

        base.ChangeStats();
    }
}
