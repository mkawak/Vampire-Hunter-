using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    protected float baseDamage;
    protected float damageMultiplier;                     // Increases with weapon level
    protected float fireRate;                             // Amount of bullets fired per minute
    public int level = 1;                              // Level of Weapon

    public GameObject player;
    protected float playerDamageMultiplier;               // Player's damage multiplier (Increased with passive items)

    public Projectile projectile;                         // Projectile to be fired by weapon
    protected int numProjectiles;                         // Number of fired projectiles
    protected float[] angles;                             // Angles at which projectiles are fired
    protected int numAngles = 0;

    protected float totalDamage = 0;                      // Total damage done by the weapon during the run

    public Sprite image;
    public string name = "Default";

    protected bool autoFire = false;
    public KeyCode keycode;

    protected virtual void Start() {
        // playerDamageMultiplier = player.GetComponent<PlayerController>().playerDamage;
    }

    protected Projectile currProj;
    public virtual void Fire() {
        playerDamageMultiplier = player.GetComponent<PlayerCharacter>().GetPlayerDamage();
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

    protected float timeTillShot = 0.3f;

    protected void Update() {
        timeTillShot -= Time.deltaTime;

        if (timeTillShot <= 0) {
            timeTillShot = 60 / fireRate;
            Fire();
        }

        // if (Input.GetKeyDown(KeyCode.K)) {
        //     LevelUp();
        // }
    }

    public void AddDamage(float amount) {
        totalDamage += amount;
    }

    public void LevelUp() {
        Debug.Log("Leveling up " + level);
        level += 1;
        Debug.Log("Leveled up " + level);
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

    // COOLDOWN TESTING
    public Image coolDown;

    protected void CoolDown() {
        if (timeTillShot == 0) timeTillShot += 0.0001f;
        coolDown.fillAmount = Mathf.Min(Mathf.Max(0, timeTillShot / (60 / fireRate)), 1);
    }
}
