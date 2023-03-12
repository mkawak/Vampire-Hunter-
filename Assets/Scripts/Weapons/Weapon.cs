using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected float baseDamage;
    protected float damageMultiplier;                     // Increases with weapon level
    protected float fireRate;                             // Amount of bullets fired per minute
    protected int level = 1;                              // Level of Weapon

    public GameObject player;
    protected float playerDamageMultiplier;               // Player's damage multiplier (Increased with passive items)

    public Projectile projectile;                         // Projectile to be fired by weapon
    protected int numProjectiles;                         // Number of fired projectiles
    protected float[] angles;                             // Angles at which projectiles are fired
    protected int numAngles = 0;

    protected float totalDamage = 0;                      // Total damage done by the weapon during the run

    public bool autoFire = true;

    protected virtual void Start() {
        // playerDamageMultiplier = player.GetComponent<PlayerController>().playerDamage;
    }

    protected Projectile currProj;
    public virtual void Fire() {
        int angleInd = 0;

        for (int i = 0; i < numProjectiles; i++) {
            float currAngle = 0;
            if (numAngles > 0) {
                if (angleInd >= numAngles) angleInd = 0;
                currAngle = angles[angleInd++];
            }

            currProj = Instantiate(projectile, transform.position, Quaternion.identity * Quaternion.Euler(Vector3.forward * currAngle) * Quaternion.Euler(transform.eulerAngles)).GetComponent<Projectile>();
            currProj.weapon = this;
            currProj.SetStats(baseDamage * damageMultiplier * playerDamageMultiplier);
        }
    }

    protected float timeTillShot = 0;

    protected void Update() {
        timeTillShot -= Time.deltaTime;

        if (timeTillShot <= 0) {
            timeTillShot = 60 / fireRate;
            Fire();
        }

        if (Input.GetKeyDown(KeyCode.K)) {
            LevelUp();
        }
    }

    public void AddDamage(float amount) {
        totalDamage += amount;
    }

    public void LevelUp() {
        level += 1;
        ChangeStats();
    }

    public int GetLevel() {
        return level;
    }

    protected virtual void ChangeStats() {
        // Override
        // Special per weapon changes at level 2 and 3 (3 and 5?)
        return;
    }
}
