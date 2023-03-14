using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_TEST : MonoBehaviour
{
    // Masato's weapon test enemy script
    public float health = 5;

    public float TakeDamage(float damage) {
        float damageTaken = damage;
        if (damage >= health) {
            damageTaken = health;
        }
        health -= damage;
        Debug.Log(health);
        return damageTaken;
    }

    public GameObject xp;
    void Die() {
        Instantiate(xp, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void Update () {
        if (health <= 0) Die();
    }
}
