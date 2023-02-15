using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    // For tweaking --------------
    public float baseDamage = 1;
    public float baseSpeed = 10f;
    public int maxWeapons = 3;
    public int maxItems = 3;
    public float baseHealth = 10;
    // ---------------------------

    protected float damage;
    protected float health;

    protected List<Weapon> weapons;
    // protected List<Item> items;
    protected PlayerController playerController;

    void Start() {
        playerController = GetComponent<PlayerController>();
    }


    public float GetPlayerDamage() {
        return damage;
    }

}
