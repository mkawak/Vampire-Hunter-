using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2_BasicAttack_Projectile : Projectile
{
    public GameObject player;
    Animator animator;

    float hitTime = 0.3f;
    float currHitTime = 0;

    List<GameObject> toHit = new List<GameObject>{};

    void Start() {
        lifeTime = 4f;
        hits = 99;

        player = GameObject.FindWithTag("Player");
        transform.parent = player.transform;
        animator = transform.GetChild(0).transform.GetComponent<Animator>();
    }

    new void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Enemy") {
            // float damageDealt = other.GetComponent<Enemy>().TakeDamage(damage);
            // weapon.AddDamage(damageDealt);
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
            weapon.AddDamage(toHit[i].GetComponent<Enemy_TEST>().TakeDamage(damage));
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
