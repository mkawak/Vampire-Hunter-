using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HealthBar : MonoBehaviour
{
    public GameObject player;

    public Slider healthbar;
    public float health = 100;

    public void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void Update()
    {
        health = player.GetComponent<PlayerCharacter>().GetHealthAsPercentage();
        healthbar.value = health;
    }

    // public void TakeDamage(float damage)
    // {
    //     Debug.Log("HB TakeDamage called.");
    //     if (damage > health) damage = health;
    //     health -= damage;
    //     //healthbar.value = (health / maxHealth) * 100;

    //     if (health <= 0)
    //     {
    //         Die();
    //     }
    // }

    // public void Heal(float healing)
    // {
    //     if(health < 100)
    //     {
    //         health += healing;
    //         //healthbar.value = health;
    //     }
      
    // }

    // public void Die()
    // {
    //     DieWindow.SetActive(true);
    //     health = 0;
    //     Debug.Log("You Died.");
    //     PauseGame();
    // }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
}