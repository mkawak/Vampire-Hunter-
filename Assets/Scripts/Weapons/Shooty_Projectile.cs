using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooty_Projectile : Projectile
{
    public Projectile explosion;
    Animator animator;

    void Start() {
        speed = 100;
        lifeTime = 1;
        hits = 1;

        animator = transform.GetChild(0).transform.GetComponent<Animator>();
    }

    new void Move() {
        transform.position += (speed * lifeTime * lifeTime * 2) * transform.right * Time.deltaTime;
    }

    new void Update() {
        Move();

        lifeTime -= Time.deltaTime;
        if (hits <= 0 || lifeTime <= 0.5f) {
            Projectile currExplosion = Instantiate(explosion, transform.position, Quaternion.identity).GetComponent<Projectile>();
            currExplosion.weapon = weapon;
            currExplosion.SetStats(damage / 2);
            Destroy(gameObject);
        }

        animator.SetFloat("lifeTime", lifeTime);
    }
}
