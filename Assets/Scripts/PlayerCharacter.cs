using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(HealthBar))]
//RequireComponent(typoeof(HealthBar))
public class PlayerCharacter : MonoBehaviour
{
    // For tweaking --------------
    public float baseDamage = 1;
    public float baseSpeed = 10f;
    public int maxWeapons = 3;
    public int maxItems = 3;
    public float baseHealth = 100;
    public float experience = 0;
    // ---------------------------

    protected float damage = 1;
    protected float health;

    float expToLevel = 10;
    int level = 1;

    protected List<Weapon> weapons;
    // protected List<Item> items;
    protected PlayerController playerController;

    void Start() {
        playerController = GetComponent<PlayerController>();
        health = baseHealth;
        gameObject.tag = "Player";

    }

    void Update(){
        RegenHealth();
        if (Input.GetKeyDown(KeyCode.K)) {
            ChangeExperience(10000);
        }
    }

    protected void RegenHealth() {
        if (health < baseHealth) {
            health += 3 * Time.deltaTime;
        }
    }

    public float GetPlayerDamage() {
        return baseDamage;
    }

    public float GetHealthAsPercentage() {
        return health / baseHealth * 100;
    }

    public int GetLevel() {
        return level;
    }

    public float GetExpAsPercentage() {
        return experience / expToLevel * 100;
    }

    public void TakeDamage(float damage){
        if (damage > health) damage = health;
        
        health -= damage;

        // update health bar
        // Debug.Log("PC calling HB::TakeDamage.");
        // playerHealthBar.TakeDamage(damage);

        if (health <= 0){
            Die();
        }
    }

    public TEST_GameManager gm;
    public void ChangeExperience(int value) {
        
        experience += value;

        if (experience >= expToLevel) {
            experience = 0;
            level++;
            expToLevel += 10;
            gm.LeveledUp();
        }
    }

    public void ChangeHealth(float value) {
        
        baseHealth += value;
        health += value;
    }

    public void ChangeDamage(float value) {
        baseDamage += value;
        Debug.Log("Damage gained: " + value);
    }

    public void ChangeSpeed(float value) {
        
        baseSpeed += value;
        Debug.Log("Speed gained: " + value);
    }

    public void Die(){
        gm.Died();
        Destroy(gameObject);
    }

}
