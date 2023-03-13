using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3_BasicAttack_Projectile : Projectile
{
    CircleCollider2D collider;
    float colliderOriginalRadius;

    GameObject target;

    bool doFind = true, found = false, movingToTarget = false;
    float maxSearchTime = 0.5f;
    float currSearchTime = 0;

    float timeTillNextSearch = 0;

    float hitTime = 0.3f;
    float currHitTime = 0;

    List<GameObject> toHit = new List<GameObject>{};

    void Start() {
        speed = 12;
        lifeTime = 100f;
        hits = 99;

        //damage = 1;

        collider = transform.GetChild(0).GetComponent<CircleCollider2D>();
        colliderOriginalRadius = collider.radius;
    }

    public void Found(Collider2D other) {
        if (other.gameObject.tag == "Enemy" && !movingToTarget) {
            target = other.gameObject;
            found = true;
        }
    }

    void FindNearestEnemy() {
        if (found) {
            collider.radius = colliderOriginalRadius; // Maybe move into FindNearestEnemy?
            doFind = false;
            found = false;
            movingToTarget = true;
            currSearchTime = 0;
        }
        else {
            currSearchTime += Time.deltaTime;
            collider.radius += collider.radius * Time.deltaTime * 5;

            if (currSearchTime >= maxSearchTime) {
                doFind = false;
                found = false;
                collider.radius = colliderOriginalRadius;
                timeTillNextSearch = 0;
                currSearchTime = 0;
            }
        }
    }

    new void Move() {
        if (target == null) base.Move();
        else {
            Vector3 vectorToTarget = (target.transform.position - transform.position).normalized;
            transform.position += speed * vectorToTarget * Time.deltaTime;
        if (
            movingToTarget &&
            transform.position.x > target.transform.position.x - 0.2f &&
            transform.position.x < target.transform.position.x + 0.2f
            ) {
            if (
                transform.position.y > target.transform.position.y - 0.2f &&
                transform.position.y < target.transform.position.y + 0.2f
                )
                doFind = true;
                movingToTarget = false;
            }
        }
        transform.GetChild(0).transform.Rotate(new Vector3(0, 0, 720) * Time.deltaTime);
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

    // What happens if target dies?
    new void Update() {
        if (timeTillNextSearch >= 0.3f) {
            if (!movingToTarget) doFind = true;
        }
        else timeTillNextSearch += Time.deltaTime;

        if (doFind) {
            FindNearestEnemy();
        }

        currHitTime -= Time.deltaTime;
        if (currHitTime < 0) {
            currHitTime = hitTime;
            Attack();
        }

        Move();
        base.Update();
    }
}
