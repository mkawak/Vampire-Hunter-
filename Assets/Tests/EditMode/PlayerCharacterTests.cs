using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerCharacterTests
{
    [Test]
    public void PlayerCharacterHealthRegenTest()
    {
        // Arrange
        var player = new GameObject().AddComponent<PlayerCharacter>();
        player.baseHealth = 100f;
        player.Start();

        // Act
        player.health = 50f;
        player.RegenHealth();

        // Assert
        Assert.AreEqual(50f, player.health, 0.1f); // expect health to be increased by 3 * deltaTime = 3 * 0.01 = 0.03
    }

}
