using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;

public class HealthBarTests
{
    [Test]
    public void HealthBarTakeDamageSuccessTest()
    {
        // Arrange
        var gameObject = new GameObject();
        var healthBar = gameObject.AddComponent<HealthBar>();
        healthBar.health = 50;
        float damage = 20;

        // Act
        healthBar.TakeDamage(damage);

        // Assert
        Assert.AreEqual(healthBar.health, 30);
    }

    [Test]
    public void HealthBarTakeDamageFailureTest()
    {
        HealthBar healthBar = new HealthBar();

        healthBar.maxHealth = 100;
        healthBar.health = 50;

        healthBar.TakeDamage(75);

        Assert.AreEqual(25, healthBar.health); // This assertion will fail
    }


    [Test]
    public void HealthBarHealSuccessTest()
    {
        // Arrange
        var gameObject = new GameObject();
        var healthBar = gameObject.AddComponent<HealthBar>();
        healthBar.health = 50;
        float healing = 20;

        // Act
        healthBar.Heal(healing);

        // Assert
        Assert.AreEqual(healthBar.health, 70);
    }

    [Test]
    public void HealthBarDieSuccessTest()
    {
        // Arrange
        var gameObject = new GameObject();
        var healthBar = gameObject.AddComponent<HealthBar>();
        var dieWindow = new GameObject();
        healthBar.DieWindow = dieWindow;
        healthBar.health = 0;

        // Act
        healthBar.Die();

        // Assert
        Assert.IsTrue(dieWindow.activeSelf);
        Assert.AreEqual(healthBar.health, 0);
        Assert.AreEqual(Time.timeScale, 0f);
    }

}
