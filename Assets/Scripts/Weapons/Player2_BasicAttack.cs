using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

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

    bool fired = false;
    public override void Fire() {
        if (level != 3) base.Fire();
        if (level == 2) currProj.transform.localScale += new Vector3(level, level, 0);
        if (level == 3) {
            if (fired) return;
            base.Fire();
            currProj.transform.localScale += new Vector3(level, level, 0);
            fired = true;
        }
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
                AudioManager.Instance.PlaySFX("FireSFX");
                Fire();
            }
        }

        if (coolDown != null) CoolDown();

        if (level == 3 && currProj != null) currProj.lifeTime = 5f;
    }

    
}
