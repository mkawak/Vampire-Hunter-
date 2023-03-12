using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo2Projectile2 : Projectile
{
    public GameObject target;

    float hitTime = 0.3f;
    float currHitTime = 0;

    List<GameObject> toHit = new List<GameObject>{};

    void Start() {
        lifeTime = 4f;
        hits = 99;
        damage = 5;
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

    new void Move() {
        transform.Rotate(new Vector3(0, 0, 120) * Time.deltaTime);
        transform.position = target.transform.position;
    }

    new void Update() {
        currHitTime -= Time.deltaTime;
        if (currHitTime < 0) {
            currHitTime = hitTime;
            Attack();
        }

        Move();
    }
}
