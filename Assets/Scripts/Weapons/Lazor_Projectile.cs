using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazor_Projectile : Projectile
{
    GameObject player;

    float hitTime = 0.1f;
    float currHitTime = 0;

    List<GameObject> toHit = new List<GameObject>{};

    void Start() {
        lifeTime = 4f;
        hits = 99;
        damage = 1;

        player = player = GameObject.FindWithTag("Player");
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

    new void Move() {
        transform.Rotate(new Vector3(0, 0, 30) * Time.deltaTime);
        transform.position = player.transform.position;
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
