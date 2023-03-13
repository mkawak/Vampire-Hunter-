using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Combo1 : Weapon
{
    protected override void Start() {

        baseDamage = 2f;
        damageMultiplier = 1.2f;
        fireRate = 10;

        numProjectiles = 1;
        angles = new float[] {0};
        numAngles = 1;

        playerDamageMultiplier = 1; //Remove

        level = 3;

        name = "Combo1";

        base.Start();
    }

    public GameObject cursorFab;
    GameObject cursor;
    void Fire() {
        Vector3 mouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z * -1);
        Vector3 target = Camera.main.ScreenToWorldPoint(mouse);

        if (cursor == null) {
            cursor = Instantiate(cursorFab, target, Quaternion.identity);
        }

        cursor.transform.position = target;

        if (Input.GetMouseButtonDown(0)) {
            // Vector3 mouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z * -1);
            // Vector3 target = Camera.main.ScreenToWorldPoint(mouse);
            Projectile currProj = Instantiate(projectile, new Vector3(target[0], target[1], 0), Quaternion.identity);
            currProj.weapon = this;
            currProj.SetStats(baseDamage * damageMultiplier * playerDamageMultiplier);
            timeTillShot = 60 / fireRate;
            firing = false;
            AudioManager.Instance.PlaySFX("LightThunderSFX");

            Destroy(cursor);
            cursor = null;
        }
    }


    bool firing = false;

    new void Update() {
        timeTillShot -= Time.deltaTime;

        if (timeTillShot <= 0 && !firing) {
            if (Input.GetKeyDown(keycode)) {
                firing = true;
            }
        }

        else if (timeTillShot <= 0 && firing) {
            Fire();
        }
        if (coolDown != null) CoolDown();
    }

    protected override void ChangeStats() {
        switch(level) {
            case 2:
                fireRate = 20;
                break;
            case 3:
                fireRate = 40;
                break;
            default:
                break;
        }

        base.ChangeStats();
    }
}
