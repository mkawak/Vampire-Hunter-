using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthbar;
    public float maxHealth;
    public float health;

    void Start()
    {
        maxHealth = 100;
        health = maxHealth;
        healthbar.value = maxHealth;
    }

    void Update()
    {
        //healthbar.value = health;
    }

    public void TakeDamge(float damage)
    {
        health -= damage;
        healthbar.value = health;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Heal(float healing)
    {
        if(health < 100)
        {
            health += healing;
            healthbar.value = health;
        }
      
    }


    public void Die()
    {
        health = 0;
        Debug.Log("You Died.");
    }
}