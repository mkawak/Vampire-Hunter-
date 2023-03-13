using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HealthBar : MonoBehaviour
{
    public Slider healthbar;
    public float maxHealth;
    public float health;
    public GameObject DieWindow;

    void Start()
    {
        maxHealth = 100;
        health = maxHealth;
        healthbar.value = maxHealth;
        DieWindow.SetActive(false);
    }

    void Update()
    {
        // debug: make bar move
        //if (health > 0) --health;
        //else health = 100;
        //Debug.Log("HB::Update health: " + health);
        //Debug.Log("HB::Update maxHealth: " + maxHealth);
        // healthbar.value = (health / maxHealth) * 100;
        //Debug.Log("HB::Update value: " + healthbar.value);
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("HB TakeDamage called.");
        if (damage > health) damage = health;
        health -= damage;
        //healthbar.value = (health / maxHealth) * 100;

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
            //healthbar.value = health;
        }
      
    }

    public void Die()
    {
        DieWindow.SetActive(true);
        health = 0;
        Debug.Log("You Died.");
        PauseGame();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
}