/*using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerControllerTests
{
    private GameObject player;

    [SetUp]
    public void Setup()
    {
        player = new GameObject();
        player.AddComponent<PlayerController>();
    }

    [UnityTest]
    public IEnumerator MoveTest()
    {
        // Arrange
        var playerController = player.GetComponent<PlayerController>();
        var initialPosition = player.transform.position;
        var deltaTime = 0.1f;

        // Act
        playerController.Move(1, 1, deltaTime);
        yield return new WaitForSeconds(deltaTime);

        // Assert
        Assert.AreNotEqual(initialPosition, player.transform.position);
    }

    [UnityTest]
    public IEnumerator SpeedTest()
    {
        // Arrange
        var playerController = player.GetComponent<PlayerController>();
        var initialSpeed = playerController.GetSpeed();
        var newSpeed = 20f;

        // Act
        playerController.SetSpeed(newSpeed);
        yield return null;

        // Assert
        Assert.AreEqual(newSpeed, playerController.GetSpeed());
        Assert.AreNotEqual(initialSpeed, playerController.GetSpeed());
    }

    [TearDown]
    public void Teardown()
    {
        Object.Destroy(player);
    }
}
*/