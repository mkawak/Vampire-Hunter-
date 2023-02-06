using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Weapon weapon;

    protected float speed;
    public float lifeTime; // In seconds
    protected float hits;
    protected float damage;

    public void SetStats(float projDamage) {
        damage = projDamage;
    }

    protected void Move() {
        transform.position += speed * transform.right * Time.deltaTime;
    }

    protected void Update() {
        lifeTime -= Time.deltaTime;
        if (hits <= 0 || lifeTime <= 0) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Enemy") {
            float damageDealt = other.GetComponent<Enemy>().TakeDamage(damage);
            weapon.AddDamage(damageDealt);
            hits -= 1;
        }

        if (other.gameObject.tag == "Wall") {
            hits -= 1;
        }
    }
}
