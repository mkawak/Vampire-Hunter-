using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
//RequireComponent(typoeof(HealthBar))
public class PlayerCharacter : MonoBehaviour
{
    // For tweaking --------------
    public float baseDamage = 1;
    public float baseSpeed = 10f;
    public int maxWeapons = 3;
    public int maxItems = 3;
    public float baseHealth = 100;
    // ---------------------------

    protected float damage;
    protected float health;
    protected HealthBar playerHealthBar;

    protected List<Weapon> weapons;
    // protected List<Item> items;
    protected PlayerController playerController;

    void Start() {
        playerController = GetComponent<PlayerController>();
        playerHealthBar = GetComponent<HealthBar>();
        health = baseHealth;
        playerHealthBar.maxHealth = baseHealth;
        playerHealthBar.health = health;

    }

    private void Update(){
        /*
        //test bar flicker
        Debug.Log("start health: " + playerHealthBar.health);
        switch(playerHealthBar.health)
        {
            case 0: playerHealthBar.health = 51;
                break;
            case 51: playerHealthBar.health = 100;
                break;
            case 100: playerHealthBar.health = 50;
                break;
            case 50: playerHealthBar.health = 0;
                break;
            default: playerHealthBar.health = 100;
                break;
        }
        Debug.Log("end health: " + playerHealthBar.health);
        */
    }

    public float GetPlayerDamage() {
        return damage;
    }

    public void TakeDamage(float damage){
        health -= damage;
        Debug.Log("Player took damage, health: " + health);

        if (health <= 0){
            Die();
        }
    }

    public void Die(){
        Destroy(gameObject);
    }

}
