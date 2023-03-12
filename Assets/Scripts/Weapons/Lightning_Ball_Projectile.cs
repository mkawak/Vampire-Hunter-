using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning_Ball_Projectile : Projectile
{
    float offset = 0;

    float hitTime = 0.1f;
    float currHitTime = 0;

    List<GameObject> toHit = new List<GameObject>{};


    void Start() {
        speed = 8;
        lifeTime = 6.1f;
        hits = 99;

        damage = 1;
    }

    bool grow = false;
    float timeSinceFlip = 0f;
    new void Move(float deltaTime) {
        base.Move();

        float currGrow = (deltaTime + Random.Range(0, 0.0001f)) * ((grow) ? 1 : -1);
        transform.localScale = new Vector3(transform.localScale.x + currGrow / 3f, transform.localScale.y + currGrow / 3f, transform.localScale.z);
        timeSinceFlip += deltaTime;
        if(timeSinceFlip > 0.7f) {
            grow = !grow;
            timeSinceFlip = 0;
        }
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
            weapon.AddDamage(toHit[i].GetComponent<Enemy_TEST>().TakeDamage(damage));
        }
    }

    new void Update() {
        currHitTime -= Time.deltaTime;
        if (currHitTime < 0) {
            currHitTime = hitTime;
            Attack();
        }

        Move(Time.deltaTime);
        base.Update();
    }
}
