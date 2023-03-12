using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Lightning_Ball : Weapon
{
    protected override void Start() {

        baseDamage = 2f;
        damageMultiplier = 1.2f;
        fireRate = 6;

        numProjectiles = 1;
        angles = new float[] {0};
        numAngles = 1;

        playerDamageMultiplier = 1; //Remove

        name = "lightningBall";

        base.Start();
    }

    public override void Fire() {
        base.Fire();
        currProj.transform.localScale += new Vector3(level, level, 0);
    }

    new void Update() {
         //base.Update();

        timeTillShot -= Time.deltaTime;

        if (timeTillShot <= 0) {
            if (autoFire) {
                timeTillShot = 60/fireRate;
                Fire();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4)) {
                timeTillShot = 60/fireRate;
                Fire();
            }
        }

        if (coolDown != null) CoolDown();
    }

    protected override void ChangeStats() {
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
    
    // COOLDOWN TESTING
    public Image coolDown;

    void CoolDown() {
        if (timeTillShot == 0) timeTillShot += 0.0001f;
        coolDown.fillAmount = Mathf.Min(Mathf.Max(0, timeTillShot / (60 / fireRate)), 1);
    }
}
