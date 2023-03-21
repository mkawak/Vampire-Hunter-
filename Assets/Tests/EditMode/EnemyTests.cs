using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

// This test case is testing the enemy can take damage correctly. 
public class EnemyTests
{
    [Test]
    public void EnemyTakeDamageTest1()
    {
        // Arrange
        var enemy = new GameObject().AddComponent<Enemy_TEST>();
        enemy.health = 10f;
        float damage = 3f;
        // Act
        float damageTaken = enemy.TakeDamage(damage);

        // Assert
        Assert.AreEqual(damage, damageTaken, 0.1f); // expect damage taken to be equal to the damage dealt
        Assert.AreEqual(7f, enemy.health, 0.1f); // expect enemy's health to be decreased by the damage taken
    }

    [Test]
    public void EnemyTakeDamageTest2()
    {
        // Arrange
        var enemy = new GameObject().AddComponent<Enemy_TEST>();
        enemy.health = 10f;
        float damage = 15f;

        // Act
        float damageTaken = enemy.TakeDamage(damage);

        // Assert
        Assert.AreEqual(10f, damageTaken, 0.1f); // expect damage taken to be capped at enemy's current health
        Assert.AreEqual(-5f, enemy.health, 0.1f); // expect enemy's health to be reduced to 0
    }

    /*[Test]
    public void EnemyDieTest()
    {
        // Arrange
        var enemy = new GameObject().AddComponent<Enemy_TEST>();
        enemy.health = 3f;
        enemy.xp = new GameObject();

        // Act
        enemy.Die();

        // Assert
        Assert.AreEqual(null, enemy.gameObject); // expect the enemy game object to be destroyed
        Assert.IsNotNull(enemy.xp); // expect the xp game object to be instantiated
    }*/
}