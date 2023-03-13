using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentry : Weapon
{
    GameObject target;
    public GameObject childToSpawn;
    GameObject child;
    CircleCollider2D childCollider;

    bool spawnedChild = false, found = false;

    float coolDownE = 3f, currCoolDown = 3f;
    int shots = 6;

    protected override void Start() {

        baseDamage = 0.5f;
        damageMultiplier = 1f;
        fireRate = 600;

        numProjectiles = 6;

        playerDamageMultiplier = 1; //Remove

        base.Start();
    }

    void SpawnChild(){
        if (spawnedChild) return;

        child = Instantiate(childToSpawn, transform.position, Quaternion.identity);
        childCollider = child.GetComponent<CircleCollider2D>();
        child.transform.parent = this.transform;

        spawnedChild = true;
    }

    void KillChild() {
        Destroy(child);
        child = null;
        childCollider = null;
        spawnedChild = false;
    }

    public void ChildTrigger(Collider2D other) {
        if (other.gameObject.tag == "Enemy") {
            target = other.gameObject;
            found = true;
        }
    }

    void FindTarget() {
        if (found) {
            KillChild();
            return;
        }
        if (!spawnedChild) SpawnChild();
        childCollider.radius = childCollider.radius + (10 * Time.deltaTime);
    }

    new void Fire() {
        Vector3 toTarget = transform.position - target.transform.position;

        Projectile currProj = Instantiate(projectile, transform.position, Quaternion.identity);
        currProj.transform.right = -toTarget;
        currProj.weapon = this;
        currProj.SetStats(baseDamage * damageMultiplier * playerDamageMultiplier);
        shots -= 1;
    }

    bool firing = false;
    new void Update() {
        if (currCoolDown >= 0) {
            currCoolDown -= Time.deltaTime;
            return;
        }
        if (Input.GetKeyDown(keycode)) firing = true;
        if (shots >= 0 && firing) {
            FindTarget();
            if (found) {
                timeTillShot -= Time.deltaTime;
                if (timeTillShot <= 0) {
                    timeTillShot = 60 / fireRate;
                    Fire();
                }
            }
        }
        else {
            currCoolDown = coolDownE;
            found = false;
            target = null;
            shots = numProjectiles;
            firing = false;
        }
    }

    protected override void ChangeStats() {
        switch(level) {
            case 2:
                coolDownE = 2f;
                break;
            case 3:
                coolDownE = 1f;
                numProjectiles = 10;
                break;
            default:
                break;
        }

        base.ChangeStats();
    }
}
