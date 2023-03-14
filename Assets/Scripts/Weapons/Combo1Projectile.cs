using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo1Projectile : Projectile
{
    Animator animator;

    float hitTime = 0.1f;
    float currHitTime = 0;

    List<GameObject> toHit = new List<GameObject>{};

    void Start() {
        speed = 0;
        lifeTime = 5f;
        hits = 99;
        animator = transform.GetChild(0).transform.GetComponent<Animator>();
    }

    new void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Enemy") {
            for (int i = 0; i < toHit.Count; i++) {
                if (toHit[i] == other.gameObject) {
                    return;
                }
            }
            toHit.Add(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Enemy") {
            for (int i = 0; i < toHit.Count; i++) {
                if (other.gameObject == toHit[i]) {toHit.RemoveAt(i); break;}
            }
        }    
    }

    void Attack() {
        for (int i = 0; i < toHit.Count; i++) {
            weapon.AddDamage(toHit[i].GetComponent<Enemy>().TakeDamage(damage));
        }
    }

    void Die() {
        Fire_Next();
        Destroy(gameObject);
    }

    new void Update() {
        currHitTime -= Time.deltaTime;
        if (currHitTime < 0) {
            currHitTime = hitTime;
            Attack();
        }

        animator.SetFloat("lifeTime", lifeTime);
        
        lifeTime -= Time.deltaTime;
        if (hits <= 0 || lifeTime <= 0) Die();
    }

    // Shoot the shooty projectiles
    public Projectile projectile;

    float [] angles = new float[]{0, 60f, 120f, 180f, 240f, 300f};
    int numAngles = 6;


    void Fire_Next() {
        for (int i = 0; i < 6; i++) {
            float currAngle = 0;
            if (numAngles > 0) {
                currAngle = angles[i];
            }

            Projectile currProj = Instantiate(projectile, transform.position, Quaternion.identity * Quaternion.Euler(Vector3.forward * currAngle) * Quaternion.Euler(transform.eulerAngles)).GetComponent<Projectile>();
            currProj.weapon = weapon;
            // currProj.SetStats(baseDamage * damageMultiplier * playerDamageMultiplier);
            currProj.SetStats(1);
        }
    }
}
