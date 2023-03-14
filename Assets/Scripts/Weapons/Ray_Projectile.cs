using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray_Projectile : Projectile
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

    new void Update() {
        currHitTime -= Time.deltaTime;
        if (currHitTime < 0) {
            currHitTime = hitTime;
            Attack();
        }

        animator.SetFloat("lifeTime", lifeTime);
        base.Update();
    }
}
